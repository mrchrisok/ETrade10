using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
      protected async Task GetAccessTokenAsync(AccessTokenParameters parameters)
      {
         try
         {
            string requestToken = Credentials.RequestToken.oauth_token;
            string requestTokenSecret = Credentials.RequestToken.oauth_token_secret;
            string verifier = parameters.oauth_verifier;

            string accessRequestHeaderValue = OAuthSvc.GetAccessRequestHeaderValue(HttpMethod.Get, requestToken, requestTokenSecret, verifier);
            var headers = new WebHeaderCollection
            {
               { HttpRequestHeader.Authorization, $"OAuth {accessRequestHeaderValue}" }
            };

            var response = await MakeRequestAsync<AccessTokenResponse, AccessTokenErrorResponse>(GetServer(EServer.OAuth), "GET", headers);

            Credentials.AccessToken = response;

            //return response;

            //var accessTokenResponse = await OAuthSvc.GetAccessTokenAsync(requestToken, requestTokenSecret, verifier);

            //Credentials.AccessToken = new AccessTokenResponse()
            //{
            //   oauth_token = accessTokenResponse.AccessToken,
            //   oauth_token_secret = accessTokenResponse.AccessTokenSecret
            //};
         }
         catch (Exception ex)
         {
            throw new Exception("GetAccessTokenAsync failed: ", ex);
         }
      }

      public class AccessTokenParameters
      {
         /// <summary>
         /// The code received by the user to authenticate with the third-party application.
         /// </summary>
         public string oauth_verifier { get; set; }
      }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class AccessTokenResponse : Response
   {
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
