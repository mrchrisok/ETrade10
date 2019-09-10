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
      /// Returns an access token.
      /// https://apisb.etrade.com/docs/api/authorization/get_access_token.html
      /// </summary>
      /// <param name="requestTokenInfo"></param>
      /// <param name="verifier"></param>
      /// <returns>an access token</returns>
      protected async Task GetAccessTokenAsync(string oauth_verifier)
      {
         try
         {
            var tokenParameters = new OAuthParameters()
            {
               HttpMethod = HttpMethod.Get,
               Url = $"{GetServer(EServer.OAuth)}access_token",
               Binding = OAuthParametersBinding.Header,
               Values = new Dictionary<string, string>
               {
                  { "oauth_callback", "oob" },
                  { "oauth_token", Credentials.RequestToken.oauth_token },
                  { "oauth_token_secret", Credentials.RequestToken.oauth_token_secret },
                  { "oauth_verifier", oauth_verifier }
               }
            };

            var tokenExpiresTime = GetTokenExpirationTime();
            var accessTokenInfo = await OAuthSvc.GetAccessTokenAsync(tokenParameters);

            Credentials.AccessToken = new AccessTokenResponse()
            {
               oauth_token = accessTokenInfo.oauth_token,
               oauth_token_secret = accessTokenInfo.oauth_token_secret,
               tokenExpiresTime = tokenExpiresTime
            };
         }
         catch (Exception ex)
         {
            throw new Exception("GetAccessTokenAsync failed: ", ex);
         }
      }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class AccessTokenResponse : Response
   {
      public DateTime tokenExpiresTime { get; set; }

      /// <summary>
      /// The consumer’s access token
      /// </summary>
      public string oauth_token { get; set; }

      /// <summary>
      /// The token secret
      /// </summary>
      public string oauth_token_secret { get; set; }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class AccessTokenErrorResponse : ErrorResponse
   {

   }
}
