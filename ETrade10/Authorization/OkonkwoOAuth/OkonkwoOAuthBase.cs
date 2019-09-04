using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public abstract class OkonkwoOAuthBase : IOkonkwoOAuth
   {
      protected readonly OAuthConfig _config;

      public OkonkwoOAuthBase(OAuthConfig config)
      {
         _config = config;
      }

      #region get request token

      /// <summary>
      /// 6.1.1. Consumer Obtains a Request Token (https://oauth.net/core/1.0a/)
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <returns></returns>
      public virtual async Task<RequestTokenInfo> GetRequestTokenAsync(HttpMethod httpMethod, Dictionary<string, string> additionalParameters = null)
      {
         var parameters = GetOAuthRequestParameters(additionalParameters);

         string signatureBaseString = GetSignatureBaseString(httpMethod, _config.RequestTokenUrl, parameters);
         //
         string signature = GetSignature(signatureBaseString, _config.ConsumerSecret);
         parameters.Add("oauth_signature", Uri.EscapeDataString(signature));

         string responseText = "";

         if (httpMethod == HttpMethod.Post)
            responseText = await GetRequestTokenByPostAsync(parameters);
         else if (httpMethod == HttpMethod.Get)
            responseText = await GetRequestTokenByPostAsync(parameters);
         else
            throw new NotImplementedException($"GetRequestTokenAsync by method: {httpMethod.Method} is not implemented.");

         return GetTokenInfo<RequestTokenInfo>(responseText);
      }

      protected virtual async Task<string> GetRequestTokenByPostAsync(Dictionary<string, string> parameters)
      {
         string oauthHeader = GetOAuthHeaderValue(HttpMethod.Get, _config.RequestTokenUrl, parameters);
         string postData = ConcatParameterList(parameters, "&") + "&oauth_signature=" + Uri.EscapeDataString(signature);
         return await PostOAuthData(_config.RequestTokenUrl, postData);
      }

      protected virtual async Task<string> GetRequestTokenByGetAsync(Dictionary<string, string> parameters)
      {
         string oauthHeader = GetOAuthHeaderValue(HttpMethod.Get, _config.RequestTokenUrl, parameters);
         string postData = ConcatParameterList(parameters, "&") + "&oauth_signature=" + Uri.EscapeDataString(signature);
         return await PostOAuthData(_config.RequestTokenUrl, postData);
      }

      #endregion

      #region get access token

      /// <summary>
      /// OAuth - 6.3.1. Consumer Requests an Access Token
      /// </summary>
      /// <param name="requestToken"></param>
      /// <param name="requestTokenSecret"></param>
      /// <param name="verifier"></param>
      /// <returns></returns>
      public virtual async Task<AccessTokenInfo> GetAccessTokenAsync(HttpMethod httpMethod, string requestToken, string requestTokenSecret, string verifier)
      {
         string nonce = GetNonce();
         string timeStamp = GetTimeStamp();

         var requestParameters = new List<string>
         {
            "oauth_consumer_key=" + _config.ConsumerKey,
            "oauth_token=" + requestToken,
            "oauth_signature_method=HMAC-SHA1",
            "oauth_timestamp=" + timeStamp,
            "oauth_nonce=" + nonce,
            "oauth_version=1.0",
            "oauth_verifier=" + verifier
         };

         string signatureBaseString = GetSignatureBaseString(httpMethod, _config.AccessTokenUrl, requestParameters);
         string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, requestTokenSecret);

         string postData = $"{ConcatParameterList(requestParameters, "&")}&oauth_signature={Uri.EscapeDataString(signature)}";

         string responseText = await PostOAuthData(_config.AccessTokenUrl, postData);

         if (!responseText.ToLowerInvariant().Contains("oauth_token"))
            throw new Exception(@"An error occured when trying to retrieve access token, the response was: """ + responseText +
                           @"""" + Environment.NewLine + Environment.NewLine +
                           "Did you remember to navigate to and complete the authorization page?");

         return GetTokenInfo<AccessTokenInfo>(responseText);
      }

      #endregion

      /// <summary>
      /// 
      /// </summary>
      /// <param name="requestToken"></param>
      /// <param name="callbackUrl">a URL the Service Provider will use to redirect the User back to the Consumer when Obtaining User Authorization is complete</param>
      /// <returns></returns>
      public virtual string GetAuthorizationUrl(string requestToken, string callbackUrl = null)
      {
         string authorizeTokenUrl = _config.AuthorizeTokenUrl.TrimEnd('/');

         string authorzationUrl = Uri.UnescapeDataString($"{authorizeTokenUrl}?oauth_token={requestToken}");

         if (!string.IsNullOrEmpty(callbackUrl))
            authorzationUrl += $"&oauth_callback={callbackUrl}";

         return authorzationUrl;
      }

      public AuthenticationHeaderValue GetOAuthHeader(HttpMethod httpMethod, string token, string tokenSecret, string url, string realm = "")
      {
         return new AuthenticationHeaderValue("OAuth", GetOAuthHeaderValue(httpMethod, token, tokenSecret, url, realm));
      }

      protected void LoadQueryStringParameters(string url, Dictionary<string, string> parameters)
      {
         var requestUri = new Uri(url, UriKind.Absolute);
         if (!string.IsNullOrWhiteSpace(requestUri.Query))
         {
            // extract non "oauth_" parameters from queryString
            var queryStringParameters = GetQueryStringParameters(requestUri.Query);

            foreach (var parameter in queryStringParameters)
               parameters.Add(parameter.Key, parameter.Value);
         }
      }

      /// <summary>
      /// OAuth 5.4.1 - Authorization Header
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="token"></param>
      /// <param name="tokenSecret"></param>
      /// <param name="url"></param>
      /// <returns></returns>
      public string GetOAuthHeaderValue(HttpMethod httpMethod, string url, Dictionary<string, string> parameters)
      {
         string token = parameters["oauth_token"];
         string tokenSecret = parameters["oauth_token_secret"];
         string realm = parameters["realm"];

         var additionalParameters = new Dictionary<string, string>();

         if (!string.IsNullOrEmpty(token))
            additionalParameters.Add("oauth_token", token);

         LoadQueryStringParameters(url, additionalParameters);

         var requestParameters = GetOAuthRequestParameters(additionalParameters);

         string signatureBaseString = GetSignatureBaseString(httpMethod, url, requestParameters);
         string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, tokenSecret);

         // wrap the parameter values with quotes
         var headerParameters = new List<string>()
         {
            $"realm=\"{realm ?? GetRealm(url)}\"", $"oauth_signature=\"{Uri.EscapeDataString(signature)}\""
         };
         foreach (var parameter in requestParameters)
            headerParameters.Add($"{parameter.Key}=\"{parameter.Value}\"");

         return ConcatParameterList(headerParameters, ",");
      }

      /// <summary>
      /// OAuth 6 - Authenticating with OAuth
      /// </summary>
      /// <param name="additionalParameters"></param>
      /// <param name="addVersion"></param>
      /// <returns></returns>
      protected virtual Dictionary<string, string> GetOAuthRequestParameters(Dictionary<string, string> additionalParameters = null)
      {
         var requestParameters = new Dictionary<string, string>
         {
            { "oauth_consumer_key", _config.ConsumerKey },
            { "oauth_signature_method", "HMAC-SHA1" },
            { "oauth_timestamp", GetTimeStamp() },
            { "oauth_nonce" , GetNonce() },
            { "oauth_version", _config.Version }
         };

         foreach (var parameter in additionalParameters)
            if (!requestParameters.ContainsKey(parameter.Key))
               requestParameters.Add(parameter.Key, parameter.Value);

         return requestParameters;
      }

      protected virtual string GetNonce()
      {
         return new Random().Next(1000000000).ToString();
      }

      protected virtual string GetTimeStamp()
      {
         var timeStamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
         return Convert.ToInt64(timeStamp.TotalSeconds).ToString();
      }

      protected virtual string GetRealm(string url)
      {
         var uri = new Uri(url, UriKind.Absolute);
         return $"{uri.Scheme}://{uri.Host}";
      }

      /// <summary>
      /// OAuth 9.1 - Generating Signature Base String
      /// </summary>
      /// <param name="method"></param>
      /// <param name="requestUrl"></param>
      /// <param name="requestParameters"></param>
      /// <returns></returns>
      protected virtual string GetSignatureBaseString(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> requestParameters)
      {
         // 9.1.1
         var sortedParameterList = new List<string>();
         foreach (var parameter in requestParameters)
            sortedParameterList.Add($"{parameter.Key}={parameter.Value}");
         sortedParameterList.Sort();
         string normalizedParameters = ConcatParameterList(sortedParameterList, "&");

         // 9.1.2
         requestUrl = ConstructRequestUrl(requestUrl);

         // 9.1.3
         return $"{httpMethod.Method.ToUpper()}&{Uri.EscapeDataString(requestUrl)}&{Uri.EscapeDataString(normalizedParameters)}";
      }

      /// <summary>
      /// OAuth 9.2 Generating Signature
      /// </summary>
      /// <param name="signatureBaseString"></param>
      /// <param name="consumerSecret"></param>
      /// <param name="tokenSecret"></param>
      /// <returns></returns>
      protected virtual string GetSignature(string signatureBaseString, string consumerSecret, string tokenSecret = null)
      {
         string key = Uri.EscapeDataString(consumerSecret) + "&" + Uri.EscapeDataString(tokenSecret ?? "");

         var hmacsha1 = new HMACSHA1 { Key = Encoding.ASCII.GetBytes(key) };

         byte[] dataBuffer = Encoding.ASCII.GetBytes(signatureBaseString);
         byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

         return Convert.ToBase64String(hashBytes);

         // .NET Core implementation
         // var signingKey = string.Format("{0}&{1}", consumerSecret, !string.IsNullOrEmpty(requestTokenSecret) ? requestTokenSecret : "");
         // IBuffer keyMaterial = CryptographicBuffer.ConvertStringToBinary(signingKey, BinaryStringEncoding.Utf8);
         // MacAlgorithmProvider hmacSha1Provider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
         // CryptographicKey macKey = hmacSha1Provider.CreateKey(keyMaterial);
         // IBuffer dataToBeSigned = CryptographicBuffer.ConvertStringToBinary(signatureBaseString, BinaryStringEncoding.Utf8);
         // IBuffer signatureBuffer = CryptographicEngine.Sign(macKey, dataToBeSigned);
         // String signature = CryptographicBuffer.EncodeToBase64String(signatureBuffer);
         // return signature;
      }

      /// <summary>
      /// Get non "oauth_" parameters from the queryString
      /// </summary>
      /// <param name="queryString"></param>
      /// <returns></returns>
      protected virtual Dictionary<string, string> GetQueryStringParameters(string queryString)
      {
         if (queryString.StartsWith("?"))
            queryString = queryString.Remove(0, 1);

         var queryParameters = new Dictionary<string, string>();

         if (string.IsNullOrEmpty(queryString))
            return queryParameters;

         foreach (string parameter in queryString.Split('&'))
            if (!string.IsNullOrEmpty(parameter) && !parameter.StartsWith("oauth_"))
               if (parameter.IndexOf('=') > -1)
               {
                  string[] parameterParts = parameter.Split('=');
                  queryParameters.Add(parameterParts[0], parameterParts[1]);
               }
               else
               {
                  queryParameters.Add(parameter, string.Empty);
               }

         return queryParameters;
      }

      /// <summary>
      /// 9.1.2.  Construct Request URL
      /// </summary>
      /// <param name="url"></param>
      /// <returns></returns>
      protected virtual string ConstructRequestUrl(string url)
      {
         var uri = new Uri(url, UriKind.Absolute);

         string normUrl = $"{uri.Scheme}://{uri.Host}";
         if (!(uri.Scheme == "http" && uri.Port == 80 || uri.Scheme == "https" && uri.Port == 443))
            normUrl += ":" + uri.Port;

         return normUrl += uri.AbsolutePath;
      }

      //protected virtual string GetNormalizedUrl(Uri uri)
      //{
      //   string normUrl = $"{uri.Scheme}://{uri.Host}";
      //   if (!(uri.Scheme == "http" && uri.Port == 80 || uri.Scheme == "https" && uri.Port == 443))
      //      normUrl += ":" + uri.Port;

      //   return normUrl += uri.AbsolutePath;
      //}

      /// <summary>
      /// OAuth 9.1.1 - Normalize Request Parameters
      /// </summary>
      /// <param name="parameters"></param>
      /// <param name="delimiter"></param>
      /// <returns></returns>
      protected virtual string ConcatParameterList(IEnumerable<string> parameters, string delimiter)
      {
         var stringBuilder = new StringBuilder();
         foreach (string parameter in parameters)
         {
            if (stringBuilder.Length > 0)
               stringBuilder.Append(delimiter);

            stringBuilder.Append(parameter);
         }
         return stringBuilder.ToString().TrimEnd(delimiter.ToCharArray());
      }

      protected virtual async Task<string> PostOAuthData(string url, string postData, Dictionary<string, string> headers = null)
      {
         try
         {
            var httpClient = new HttpClient { MaxResponseContentBufferSize = int.MaxValue };
            httpClient.DefaultRequestHeaders.ExpectContinue = false;

            var requestMsg = new HttpRequestMessage
            {
               Content = new StringContent(postData),
               Method = new HttpMethod("POST"),
               RequestUri = new Uri(url, UriKind.Absolute)
            };
            requestMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await httpClient.SendAsync(requestMsg);
            return await response.Content.ReadAsStringAsync();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      protected T GetTokenInfo<T>(string responseText) where T : TokenInfo, new()
      {
         if (!string.IsNullOrEmpty(responseText))
         {
            string oauthToken = null;
            string oauthTokenSecret = null;
            //string oauthAuthorizeUrl = null;

            string[] keyValPairs = responseText.Split('&');

            for (int i = 0; i < keyValPairs.Length; i++)
            {
               string[] splits = keyValPairs[i].Split('=');
               switch (splits[0])
               {
                  case "oauth_token":
                     oauthToken = splits[1];
                     break;
                  case "oauth_token_secret":
                     oauthTokenSecret = splits[1];
                     break;
                     // TODO: Handle this one?
                     //case "xoauth_request_auth_url":
                     //	oauthAuthorizeUrl = splits[1];
                     //	break;
               }
            }

            return new T()
            {
               oauth_token = oauthToken,
               oauth_token_secret = oauthTokenSecret
            };
         }

         throw new ApplicationException("Empty response text.");
      }
   }
}
