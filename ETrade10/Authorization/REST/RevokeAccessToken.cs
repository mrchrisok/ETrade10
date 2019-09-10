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
      /// Revokes an OAuth access token.
      /// https://apisb.etrade.com/docs/api/authorization/renew_access_token.html
      /// </summary>
      /// <param name="requestTokenInfo"></param>
      /// <param name="verifier"></param>
      /// <returns>an access token</returns>
      protected async Task RevokeAccessTokenAsync()
      {
         try
         {
            var tokenParameters = new OAuthParameters()
            {
               HttpMethod = HttpMethod.Get,
               Url = $"{GetServer(EServer.OAuth)}revoke_access_token",
               Binding = OAuthParametersBinding.Header,
               Values = new Dictionary<string, string>
               {
                  { "oauth_callback", "oob" },
                  { "oauth_token", Credentials.AccessToken.oauth_token },
                  { "oauth_token_secret", Credentials.AccessToken.oauth_token_secret }
               }
            };

            var accessTokenInfo = await OAuthSvc.RevokeAccessTokenAsync(tokenParameters);

            Credentials.AccessToken = null;
         }
         catch (Exception ex)
         {
            throw new Exception("RenewAccessTokenAsync failed: ", ex);
         }
      }

      public class RevokeAccessTokenParameters
      {

      }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class RevokeAccessTokenResponse : AccessTokenResponse
   {
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class RevokeAccessTokenErrorResponse : AccessTokenErrorResponse
   {

   }
}
