using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API returns a temporary request token that begins the OAuth process. 
      /// The request token must accompany the user to the authorization page, where the user will grant your application limited access to the account. The token expires after five minutes.
      /// https://apisb.etrade.com/docs/api/authorization/request_token.html
      /// </summary>
      protected async Task GetRequestTokenAsync()
      {
         try
         {
            var tokenParameters = new OAuthParameters()
            {
               TokenAction = "get-request",
               HttpMethod = HttpMethod.Get,
               Url = $"{GetServer(EServer.OAuth)}request_token",
               Binding = OAuthParametersBinding.Header,
               Values = new Dictionary<string, string>() { { "oauth_callback", "oob" } }
            };

            var requestTokenInfo = await OAuthSvc.GetRequestTokenAsync(tokenParameters);

            Credentials.RequestToken = new RequestTokenResponse()
            {
               oauth_token = requestTokenInfo.oauth_token,
               oauth_token_secret = requestTokenInfo.oauth_token_secret,
               oauth_callback_confirmed = requestTokenInfo.oauth_callback_confirmed
            };
         }
         catch (Exception ex)
         {
            throw new Exception("GetRequestTokenAsync failed: ", ex);
         }
      }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class RequestTokenResponse : Response
   {
      /// <summary>
      /// The consumer's request token	
      /// </summary>
      public string oauth_token { get; set; }

      /// <summary>
      /// The consumer's request token secret.
      /// </summary>
      public string oauth_token_secret { get; set; }

      /// <summary>
      /// Returns true if a callback URL is configured for the current consumer key, otherwise false. 
      /// Callbacks are described under the Authorize Application API.	
      /// </summary>
      public bool oauth_callback_confirmed { get; set; }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class RequestTokenErrorResponse : ErrorResponse
   {

   }
}
