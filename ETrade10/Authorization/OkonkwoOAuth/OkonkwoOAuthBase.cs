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
   public abstract class OkonkwoOAuthBase : IOAuthService
   {
      protected OAuthConfig _config;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="config"></param>
      public virtual void Initialize(OAuthConfig config)
      {
         _config = config;
      }

      /// <summary>
      /// OAuth1.0a - 6.1.1. - Consumer Obtains a Request Token (https://oauth.net/core/1.0a/)
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
      /// OAuth1.0a - 6.2 - Obtaining User Authorization
      /// </summary>
      /// <returns></returns>
      public abstract Task<string> AuthorizeApplicationAsync();

      /// <summary>
      /// OAuth1.0a - 6.3.1. - Consumer Requests an Access Token
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

      /// <summary>
      /// This behavior is optional. Implement as needed via an override in a sub-class.
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public virtual Task<AccessTokenInfo> RenewAccessTokenAsync(OAuthParameters parameters)
      {
         throw new NotImplementedException("This behavior is optional. Implement as needed via an override in a sub-class.");
      }

      /// <summary>
      /// This behavior is optional. Implement as needed via an override in a sub-class.
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public virtual Task<AccessTokenInfo> RevokeAccessTokenAsync(OAuthParameters parameters)
      {
         throw new NotImplementedException("This behavior is optional. Implement as needed via an override in a sub-class.");
      }

      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="parameters"></param>
      /// <returns></returns>
      protected virtual async Task<T> SendTokenRequestAsync<T>(OAuthParameters parameters) where T : TokenInfo, new()
      {
         if (!(parameters.HttpMethod.Equals(HttpMethod.Get) || parameters.HttpMethod.Equals(HttpMethod.Post)))
            throw new NotImplementedException($"GetRequestTokenAsync by method: {parameters.HttpMethod.Method} is not implemented.");
         //

         var requestParameters = parameters.Values;
         if (requestParameters.TryGetValue("oauth_token_secret", out string oauth_token_secret))
            requestParameters.Remove("oauth_token_secret");

         string signatureBaseString = GetSignatureBaseString(parameters.HttpMethod, parameters.Url, requestParameters);
         string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, oauth_token_secret);
         requestParameters.Add("oauth_signature", Uri.EscapeDataString(signature));

         string requestUrl = parameters.Binding == OAuthParametersBinding.QueryString
            ? $"{parameters.Url}?{ConcatParameterList(requestParameters, "&", quotedValues: true)}"
            : parameters.Url;

         var oauthHeader = parameters.Binding == OAuthParametersBinding.Header
            ? GetOAuthHeader(parameters.HttpMethod, parameters.Url, requestParameters)
            : null;

         string postData = parameters.Binding == OAuthParametersBinding.Body
            ? $"{ConcatParameterList(requestParameters, "&", quotedValues: true)}"
            : null;

         string responseText = await SendOAuthDataAsync(parameters.HttpMethod, requestUrl, oauthHeader, postData);

         if (!responseText.ToLowerInvariant().Contains("oauth_token"))
         {
            var builder = new StringBuilder($"An error occured when trying to {parameters.HttpMethod.Method}: {parameters.Url}.");
            builder.Append($"The response was: >> { responseText} <<\n\n");
            throw new Exception(builder.ToString());
         }

         return GetTokenInfo<T>(responseText);
      }

      /// <summary>
      /// OAuth1.0a - 6.2.1. - Consumer Directs the User to the Service Provider
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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="url"></param>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public virtual AuthenticationHeaderValue GetOAuthHeader(HttpMethod httpMethod, string url, Dictionary<string, string> parameters)
      {
         return new AuthenticationHeaderValue("OAuth", GetOAuthHeaderValue(httpMethod, url, parameters));
      }

      /// <summary>
      /// OAuth1.0a - 5.4.1 - Authorization Header
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="url"></param>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public virtual string GetOAuthHeaderValue(HttpMethod httpMethod, string url, Dictionary<string, string> parameters)
      {
         LoadQueryStringParameters(url, loadIntoDict: parameters);

         var headerParameters = GetOAuthRequestParameters(parameters);

         if (!headerParameters.ContainsKey("oauth_signature"))
         {
            headerParameters.TryGetValue("oauth_token_secret", out string oauth_token_secret);
            headerParameters.Remove("oauth_token_secret");
            //
            string signatureBaseString = GetSignatureBaseString(httpMethod, url, headerParameters);
            string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, oauth_token_secret);
            parameters.Add("oauth_signature", Uri.EscapeDataString(signature));
         }

         return ConcatParameterList(headerParameters, ",", quotedValues: true);
      }

      /// <summary>
      /// OAuth1.0a - 6 - Authenticating with OAuth
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
      /// OAuth1.0a - 8 - Nonce and Timestamp
      /// </summary>
      /// <returns></returns>
      protected virtual string GetNonce()
      {
         return new Random().Next(1000000000).ToString();
      }

      /// <summary>
      /// OAuth1.0a - 8 - Nonce and Timestamp
      /// </summary>
      /// <returns></returns>
      protected virtual string GetTimeStamp()
      {
         var timeStamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
         return Convert.ToInt64(timeStamp.TotalSeconds).ToString();
      }

      /// <summary>
      /// OAuth1.0a - 9.1 - Generating Signature Base String
      /// </summary>
      /// <param name="httpMethod"></param>
      /// <param name="requestUrl"></param>
      /// <param name="requestParameters"></param>
      /// <returns></returns>
      protected virtual string GetSignatureBaseString(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> requestParameters)
      {
         // 9.1.1
         string normalizedParameters = GetNormalizedParameters(requestParameters);

         // 9.1.2
         string signaturetUrl = ConstructRequestUrl(requestUrl);

         // 9.1.3
         return $"{httpMethod.Method.ToUpper()}&{Uri.EscapeDataString(signaturetUrl)}&{Uri.EscapeDataString(normalizedParameters)}";
      }

      /// <summary>
      /// OAuth1.0a - 9.2 - Generating Signature
      /// </summary>
      /// <param name="signatureBaseString"></param>
      /// <param name="consumerSecret"></param>
      /// <param name="tokenSecret"></param>
      /// <returns></returns>
      protected virtual string GetSignature(string signatureBaseString, string consumerSecret, string tokenSecret)
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
      /// OAuth1.0a - 9.1.1 - Normalize Request Parameters
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      protected virtual string GetNormalizedParameters(Dictionary<string, string> parameters)
      {
         var normalizedParameters1 = new Dictionary<string, string>(parameters);
         normalizedParameters1.Remove("realm");

         var normalizedParameters2 = normalizedParameters1.OrderBy(p => $"{p.Key}={p.Value}")
                                                          .ToDictionary(p => p.Key, p => p.Value);

         return ConcatParameterList(normalizedParameters2, "&", quotedValues: false);
      }

      /// <summary>
      /// OAuth1.0a - 9.1.2 - Construct Request URL
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
      /// Concatenate members of a Dictionary<string, string> into a delimited string
      /// </summary>
      /// <param name="parameters"></param>
      /// <param name="delimiter"></param>
      /// <param name="quotedValues"></param>
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
      /// <param name="loadIntoDict"></param>
      protected virtual void LoadQueryStringParameters(string url, Dictionary<string, string> loadIntoDict)
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

            string[] keyValuePairs = responseText.Split('&');

            foreach (string keyValuePair in keyValuePairs)
            {
               string[] keyValueData = keyValuePair.Split('=');

               switch (keyValueData[0])
               {
                  case "oauth_token":
                     oauthToken = keyValueData[1];
                     break;
                  case "oauth_token_secret":
                     oauthTokenSecret = keyValueData[1];
                     break;
                  case "oauth_callback_confirmed":
                     oauthCallbackConfirmed = keyValueData[1];
                     break;
               }
            }

            var tokenInfo = new T() { oauth_token = oauthToken, oauth_token_secret = oauthTokenSecret };

            if (tokenInfo is RequestTokenInfo requestTokenInfo)
               requestTokenInfo.oauth_callback_confirmed = Convert.ToBoolean(oauthCallbackConfirmed ?? "false");

            return tokenInfo;
         }

         throw new ArgumentException("Response text is null or empty.");
      }
   }
}
