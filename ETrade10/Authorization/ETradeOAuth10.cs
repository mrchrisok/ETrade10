using System.Composition;
using System.Threading.Tasks;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;

namespace OkonkwoETrade10.Authorization
{
   /// <summary>
   /// https://oauth.net/core/1.0a/
   /// https://oauth1.wp-api.org/docs/basics/Auth-Flow.html
   /// </summary>
   [Export("ETradeOAuthService", typeof(IOAuthService))]
   public class ETradeOAuth10 : OkonkwoOAuthBase
   {
      /// <summary>
      /// 6.2.1. Consumer Directs the User to the Service Provider
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public override string GetAuthorizationUrl(OAuthParameters parameters)
      {
         if (parameters.Binding == OAuthParametersBinding.QueryString)
         {
            string baseUrl = base.GetAuthorizationUrl(parameters);
            //
            return baseUrl.Replace("oauth_consumer_key", "key").Replace("oauth_token", "token");
         }

         return parameters.Url;
      }

      /// <summary>
      /// OAuth1.0a - 6.2 - Obtaining User Authorization
      /// </summary>
      /// <returns></returns>
      public override async Task<string> AuthorizeApplicationAsync()
      {
         //throw new System.NotImplementedException();

         return await Task.FromResult("");
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public override async Task<AccessTokenInfo> RenewAccessTokenAsync(OAuthParameters parameters)
      {
         return await SendTokenRequestAsync<AccessTokenInfo>(parameters);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public override async Task<AccessTokenInfo> RevokeAccessTokenAsync(OAuthParameters parameters)
      {
         return await SendTokenRequestAsync<AccessTokenInfo>(parameters);
      }
   }
}
