using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public class OkonkwoOAuthMessageHandler : DelegatingHandler
   {
      private readonly string _accessToken;
      private readonly string _accessTokenSecret;
      private ETradeOAuth10 _tinyOAuth;

      public OkonkwoOAuthMessageHandler(OAuthConfig config, string accessToken, string accessTokenSecret)
         : base(new HttpClientHandler())
      {
         _tinyOAuth = new ETradeOAuth10(config);
         _accessTokenSecret = accessTokenSecret;
         _accessToken = accessToken;
      }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         var authorizationHeader = _tinyOAuth.GetOAuthHeader(request.Method, _accessToken, _accessTokenSecret, request.RequestUri.AbsoluteUri);
         request.Headers.Authorization = authorizationHeader;

         //
         return base.SendAsync(request, cancellationToken);
      }
   }
}
