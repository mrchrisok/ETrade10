using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public class OkonkwoOAuthMessageHandler : DelegatingHandler
   {
      private readonly string _accessToken;
      private readonly string _accessTokenSecret;
      private IOAuthService _oauthSvc;

      public OkonkwoOAuthMessageHandler(IOAuthService oauthSvc, string accessToken, string accessTokenSecret)
         : base(new HttpClientHandler())
      {
         _oauthSvc = oauthSvc;
         _accessTokenSecret = accessTokenSecret;
         _accessToken = accessToken;
      }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         var parameters = new Dictionary<string, string>
         {
            { "oauth_token", _accessToken },
            { "oauth_token_secret", _accessTokenSecret }
         };

         request.Headers.Authorization = _oauthSvc.GetOAuthHeader(request.Method, request.RequestUri.AbsoluteUri, parameters);

         //
         return base.SendAsync(request, cancellationToken);
      }
   }
}
