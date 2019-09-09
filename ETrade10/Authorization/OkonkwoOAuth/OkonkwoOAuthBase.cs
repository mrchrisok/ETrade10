using System;
using System.Collections.Generic;
using System.Linq;
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

      /// <summary>
      /// 6.1.1. Consumer Obtains a Request Token (https://oauth.net/core/1.0a/)
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="additionalParameters"></param>
      /// <returns></returns>
      public virtual async Task<RequestTokenInfo> GetRequestTokenAsync(OAuthParameters parameters)
      {
         parameters.Values = GetOAuthRequestParameters(parameters.Values);

         return await SendTokenRequestAsync<RequestTokenInfo>(parameters);
      }

      /// <summary>
      /// OAuth - 6.3.1. Consumer Requests an Access Token
      /// </summary>
      /// <param name="requestToken"></param>
      /// <param name="requestTokenSecret"></param>
      /// <param name="verifier"></param>
      /// <returns></returns>
      public virtual async Task<AccessTokenInfo> GetAccessTokenAsync(OAuthParameters parameters)
      {
         parameters.Values = GetOAuthRequestParameters(parameters.Values);

         return await SendTokenRequestAsync<AccessTokenInfo>(parameters);
      }

      protected virtual async Task<T> SendTokenRequestAsync<T>(OAuthParameters parameters) where T : TokenInfo, new()
      {
         if (!(parameters.HttpMethod.Equals(HttpMethod.Get) || parameters.HttpMethod.Equals(HttpMethod.Post)))
            throw new NotImplementedException($"GetRequestTokenAsync by method: {parameters.HttpMethod.Method} is not implemented.");

         // build parameters
         var requestParameters = parameters.Values;
         if (requestParameters.TryGetValue("oauth_token_secret", out string oauth_token_secret))
            requestParameters.Remove("oauth_token_secret");

         string signatureBaseString = GetSignatureBaseString(parameters.HttpMethod, parameters.Url, requestParameters);
         string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, oauth_token_secret);
         requestParameters.Add("oauth_signature", Uri.EscapeDataString(signature));

         var requestUrl = parameters.Binding == OAuthParametersBinding.QueryString
            ? $"{parameters.Url}?{ConcatParameterList(requestParameters, "&", quotedValues: true)}"
            : parameters.Url;

         var oauthHeader = parameters.Binding == OAuthParametersBinding.Header
            ? GetOAuthHeader(parameters.HttpMethod, parameters.Url, requestParameters)
            : null;

         var postData = parameters.Binding == OAuthParametersBinding.Body
            ? $"{ConcatParameterList(requestParameters, "&", quotedValues: true)}"
            : null;

         string responseText = await SendOAuthDataAsync(parameters.HttpMethod, requestUrl, oauthHeader, postData);

         if (!responseText.ToLowerInvariant().Contains("oauth_token"))
         {
            string[] tokenAction = parameters.TokenAction.Split('-');
            var builder = new StringBuilder($"An error occured during the when trying to {tokenAction[0]} {tokenAction[1]} token.");
            builder.Append($"The response was: >> { responseText} <<\n\n");
            throw new Exception(builder.ToString());
         }

         return GetTokenInfo<T>(responseText);
      }

      /// <summary>
      /// 6.2.1. Consumer Directs the User to the Service Provider
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public virtual string GetAuthorizationUrl(OAuthParameters parameters)
      {
         string authorizeTokenUrl = parameters.Url.TrimEnd('/');
         string requestToken = parameters.Values["oauth_token"];

         string authorzationUrl = Uri.UnescapeDataString($"{authorizeTokenUrl}?oauth_consumer_key={_config.ConsumerKey}&oauth_token={requestToken}");

         if (parameters.Values.TryGetValue("oauth_callback", out string oauth_callback))
            authorzationUrl += $"&oauth_callback={oauth_callback}";

         return authorzationUrl;
      }

      public AuthenticationHeaderValue GetOAuthHeader(HttpMethod httpMethod, string url, Dictionary<string, string> parameters)
      {
         return new AuthenticationHeaderValue("OAuth", GetOAuthHeaderValue(httpMethod, url, parameters));
      }

      /// <summary>
      /// OAuth 5.4.1 - Authorization Header
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="url"></param>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public string GetOAuthHeaderValue(HttpMethod httpMethod, string url, Dictionary<string, string> parameters)
      {
         LoadQueryStringParameters(url, loadIntoDict: parameters);

         if (!parameters.ContainsKey("oauth_signature"))
         {
            parameters.TryGetValue("oauth_token_secret", out string oauth_token_secret);
            //
            string signatureBaseString = GetSignatureBaseString(httpMethod, url, parameters);
            string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, oauth_token_secret);
            parameters.Add("oauth_signature", Uri.EscapeDataString(signature));
         }

         parameters.TryGetValue("realm", out string realm);

         return $"realm=\"{realm ?? ""}\",{ConcatParameterList(parameters, ",", quotedValues: true)}";
      }

      /// <summary>
      /// OAuth 6 - Authenticating with OAuth
      /// </summary>
      /// <param name="requestParameters"></param>
      /// <returns></returns>
      protected virtual Dictionary<string, string> GetOAuthRequestParameters(Dictionary<string, string> requestParameters = null)
      {
         var oauthParameters = new Dictionary<string, string>
         {
            { "oauth_consumer_key", _config.ConsumerKey },
            { "oauth_signature_method", "HMAC-SHA1" },
            { "oauth_timestamp", GetTimeStamp() },
            { "oauth_nonce" , GetNonce() },
            { "oauth_version", _config.Version }
         };

         if (requestParameters == null)
            return oauthParameters;

         foreach (var parameter in oauthParameters)
            if (!requestParameters.ContainsKey(parameter.Key))
               requestParameters.Add(parameter.Key, parameter.Value);

         return requestParameters;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      protected virtual string GetNonce()
      {
         return new Random().Next(1000000000).ToString();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      protected virtual string GetTimeStamp()
      {
         var timeStamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
         return Convert.ToInt64(timeStamp.TotalSeconds).ToString();
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
         var signatureParameters = requestParameters.OrderBy(p => $"{p.Key}={p.Value}")
                                                    .ToDictionary(p => p.Key, p => p.Value);
         string normalizedParameters = ConcatParameterList(signatureParameters, "&", quotedValues: false);

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
         string key = $"{GetEscapedDataString(consumerSecret)}&{GetEscapedDataString(tokenSecret ?? "")}";

         using (var hmacsha1 = new HMACSHA1 { Key = Encoding.ASCII.GetBytes(key) })
         {
            byte[] dataBuffer = Encoding.ASCII.GetBytes(signatureBaseString);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
         }
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

      /// <summary>
      /// OAuth 9.1.1 - Normalize Request Parameters
      /// </summary>
      /// <param name="parameters"></param>
      /// <param name="delimiter"></param>
      /// <returns></returns>
      protected virtual string ConcatParameterList(Dictionary<string, string> parameters, string delimiter, bool quotedValues = false)
      {
         var stringBuilder = new StringBuilder();
         string escapedQuote = quotedValues ? "\"" : null;

         foreach (var parameter in parameters)
         {
            if (stringBuilder.Length > 0)
               stringBuilder.Append(delimiter);

            stringBuilder.Append($"{parameter.Key}={escapedQuote}{ parameter.Value}{escapedQuote}");

         }

         return stringBuilder.ToString().TrimEnd(delimiter.ToCharArray());
      }

      /// <summary>
      /// Returns the passed-in stringData as a uri/percent escaped string
      /// If the stringData has already been escaped, the stringData will be returned unchanged.
      /// </summary>
      /// <param name="stringData"></param>
      /// <returns></returns>
      protected virtual string GetEscapedDataString(string stringData)
      {
         string[] splitStringData = stringData?.Split('%');

         // this is a rudimentary check to see if stringData has already been escaped
         // more sophisticated implementations can be implemented by overriding this method
         if (splitStringData?.Length > 1)
            if (splitStringData.Skip(1).ToArray().Any(data => data.Length >= 2))
               return stringData;

         return Uri.EscapeDataString(stringData);
      }

      /// <summary>
      /// Extracts and loads non "oauth_" parameters from queryString into a dictionary
      /// </summary>
      /// <param name="url"></param>
      /// <param name="parameters"></param>
      protected void LoadQueryStringParameters(string url, Dictionary<string, string> loadIntoDict)
      {
         var requestUri = new Uri(url, UriKind.Absolute);

         if (!string.IsNullOrWhiteSpace(requestUri.Query))
            foreach (string parameter in requestUri.Query.Split('&'))
               if (!string.IsNullOrEmpty(parameter) && !parameter.StartsWith("oauth_"))
                  if (parameter.IndexOf('=') > -1)
                  {
                     string[] parameterParts = parameter.Split('=');
                     loadIntoDict.Add(parameterParts[0], parameterParts[1]);
                  }
                  else
                  {
                     loadIntoDict.Add(parameter, string.Empty);
                  }
      }

      /// <summary>
      /// Sends the oauth message to the oauth service
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="url"></param>
      /// <param name="authHeader"></param>
      /// <param name="postData"></param>
      /// <returns></returns>
      protected virtual async Task<string> SendOAuthDataAsync(HttpMethod httpMethod, string url, AuthenticationHeaderValue authHeader, string postData)
      {
         try
         {
            using (var httpClient = new HttpClient { MaxResponseContentBufferSize = int.MaxValue })
            {
               httpClient.DefaultRequestHeaders.ExpectContinue = false;
               httpClient.DefaultRequestHeaders.Authorization = authHeader;

               var requestMsg = new HttpRequestMessage()
               {
                  Method = httpMethod,
                  RequestUri = new Uri(url, UriKind.Absolute)
               };

               if (httpMethod.Equals(HttpMethod.Post))
               {
                  requestMsg.Content = new StringContent(postData);
                  requestMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
               }

               var response = await httpClient.SendAsync(requestMsg);
               return await response.Content.ReadAsStringAsync();
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// Get token info from response text
      /// </summary>
      /// <typeparam name="T">Type of token info</typeparam>
      /// <param name="responseText">Response text to extrace token info from</param>
      /// <returns></returns>
      protected T GetTokenInfo<T>(string responseText) where T : TokenInfo, new()
      {
         if (!string.IsNullOrEmpty(responseText))
         {
            string oauthToken = null;
            string oauthTokenSecret = null;
            string oauthCallbackConfirmed = null;

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
                  case "oauth_callback_confirmed":
                     oauthCallbackConfirmed = splits[1];
                     break;
               }
            }

            var tokenInfo = new T() { oauth_token = oauthToken, oauth_token_secret = oauthTokenSecret };

            if (tokenInfo is RequestTokenInfo requestTokenInfo)
               requestTokenInfo.oauth_callback_confirmed = Convert.ToBoolean(oauthCallbackConfirmed);

            return tokenInfo;
         }

         throw new Exception("Empty response text.");
      }
   }
}
