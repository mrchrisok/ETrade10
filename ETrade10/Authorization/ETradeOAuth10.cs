using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   //https://oauth.net/core/1.0a/
   //https://oauth1.wp-api.org/docs/basics/Auth-Flow.html
   public class ETradeOAuth10 : OkonkwoOAuthBase
   {
      public ETradeOAuth10(OAuthConfig config) : base(config)
      {
      }

      /// <summary>
      /// 6.2.1. Consumer Directs the User to the Service Provider
      /// </summary>
      /// <param name="requestToken"></param>
      /// <param name="callbackUrl"></param>
      /// <returns></returns>
      public override string GetAuthorizationUrl(string requestToken, string callbackUrl = null)
      {
         string authorizeTokenUrl = _config.AuthorizeTokenUrl.TrimEnd('/');

         return Uri.UnescapeDataString($"{authorizeTokenUrl}?key={ _config.ConsumerKey}&token={requestToken}");
      }

      public string GetAccessRequestHeaderValue(HttpMethod httpMethod, string token, string tokenSecret, string verifier = null)
      {
         #region oauth specification

         /*5.2.  Consumer Request Parameters

         OAuth Protocol Parameters are sent from the Consumer to the Service Provider in one of three methods, in order of decreasing preference:

         In the HTTP Authorization header as defined in OAuth HTTP Authorization Scheme.
         As the HTTP POST request body with a content-type of application/x-www-form-urlencoded.
         Added to the URLs in the query part (as defined by [RFC3986] section 3).
         In addition to these defined methods, future extensions may describe alternate methods for sending the OAuth Protocol Parameters. The methods for sending other request parameters are left undefined, but SHOULD NOT use the OAuth HTTP Authorization Scheme header.

            */

         /* 5.4.1.  Authorization Header

         The OAuth Protocol Parameters are sent in the Authorization header the following way:

         Parameter names and values are encoded per Parameter Encoding.
         For each parameter, the name is immediately followed by an ‘=’ character (ASCII code 61), a ‘”’ character (ASCII code 34), the parameter value (MAY be empty), and another ‘”’ character (ASCII code 34).
         Parameters are separated by a comma character (ASCII code 44) and OPTIONAL linear whitespace per [RFC2617].
         The OPTIONAL realm parameter is added and interpreted per [RFC2617], section 1.2.
         For example:

         Authorization: OAuth realm="http://sp.example.com/",
         oauth_consumer_key="0685bd9184jfhq22",
         oauth_token="ad180jjd733klru7",
         oauth_signature_method="HMAC-SHA1",
         oauth_signature="wOJIO9A2W5mFwDgiDvZbTSMK%2FPY%3D",
         oauth_timestamp="137131200",
         oauth_nonce="4572616e48616d6d65724c61686176",
         oauth_version="1.0"

         */

         #endregion

         string nonce = GetNonce();
         string timeStamp = GetTimeStamp();

         var requestParameters = new List<string>
         {
            "oauth_consumer_key=" + _config.ConsumerKey,
            "oauth_token=" + token,
            "oauth_signature_method=HMAC-SHA1",
            "oauth_timestamp=" + timeStamp,
            "oauth_nonce=" + nonce
         };
         if (!string.IsNullOrEmpty(verifier))
            requestParameters.Add("oauth_verifier=" + verifier);

         string signatureBaseString = GetSignatureBaseString(httpMethod, _config.AccessTokenUrl, requestParameters);
         string signature = GetSignature(signatureBaseString, _config.ConsumerSecret, tokenSecret);

         // Same as request parameters but uses a quote (") character around its values and is comma separated
         var requestParametersForHeader = new List<string>
         {
            "realm=\"\"",
            "oauth_consumer_key=\"" + _config.ConsumerKey + "\"",
            "oauth_token=\"" + token + "\"",
            "oauth_signature_method=\"HMAC-SHA1\"",
            "oauth_timestamp=\"" + timeStamp + "\"",
            "oauth_nonce=\"" + nonce + "\"",
            "oauth_signature=\"" + Uri.EscapeDataString(signature) + "\""
         };
         if (!string.IsNullOrEmpty(verifier))
            requestParametersForHeader.Add("oauth_verifier=\"" + verifier + "\"");

         return ConcatParameterList(requestParametersForHeader, ",");
      }
   }
}
