using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;
using OkonkwoETrade10.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OkonkwoETrade10.REST
{
   /// <summary>
   /// http://developer.oanda.com/rest-live-v20/introduction/
   /// </summary>
   public partial class ETrade10
   {
      private static readonly Dictionary<EEnvironment, Dictionary<EServer, string>> Servers;

      private IWebDriver WebDriver { get; }
      public Credentials Credentials { get; protected set; }

      private Configuration _config;
      private IOAuthService OAuthSvc;

      public ETrade10(IOAuthService oauthService, IWebDriver webDriver)
      {
         OAuthSvc = oauthService;

         if (webDriver == null)
         {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            WebDriver = new ChromeDriver(System.Environment.CurrentDirectory, options);
         }
         else
         {
            WebDriver = webDriver;
            WebDriver.Manage().Window.Minimize();
         }
      }

      #region initialization

      static ETrade10()
      {
         Servers = new Dictionary<EEnvironment, Dictionary<EServer, string>>
         {
            {  EEnvironment.Sandbox, new Dictionary<EServer, string>
               {
                  {EServer.OAuth, "https://apisb.etrade.com/oauth/"},
                  {EServer.Authorize, "https://us.etrade.com/e/t/etws/authorize/"},
                  {EServer.Accounts, "https://apisb.etrade.com/v1/accounts/"},
                  {EServer.Alerts, "https://apisb.etrade.com/v1/user/alerts"},
                  {EServer.Market, "https://apisb.etrade.com/v1/market/"}
               }
            },

            {  EEnvironment.Production, new Dictionary<EServer, string>
               {
                  {EServer.OAuth, "https://api.etrade.com/oauth/"},
                  {EServer.Authorize, "https://us.etrade.com/e/t/etws/authorize/"},
                  {EServer.Accounts, "https://api.etrade.com/v1/accounts/"},
                  {EServer.Alerts, "https://api.etrade.com/v1/user/alerts"},
                  {EServer.Market, "https://api.etrade.com/v1/market/"}
               }
            }
         };
      }
      public bool HasServer(EServer server)
      {
         return Servers[Credentials.environment].ContainsKey(server);
      }
      public string GetServer(EServer server)
      {
         if (HasServer(server))
            return Servers[Credentials.environment][server];

         throw new ArgumentException($"Server ({server.ToString()}) is not supported.");
      }

      public async Task Initialize(Credentials credentials, Configuration config = null)
      {
         Credentials = credentials;
         _config = config ?? new Configuration();

         var oauthConfig = new OAuthConfig()
         {
            Version = "1.0",
            ConsumerKey = Credentials.consumerKey,
            ConsumerSecret = Credentials.consumerSecret
         };

         OAuthSvc.Initialize(oauthConfig);

         await GetRequestTokenAsync();
         //
         var authorizeResponse = await AuthorizeApplicationAsync();
         //
         await GetAccessTokenAsync(authorizeResponse.oauth_verifier);
      }
      #endregion

      #region request

      /// <summary>
      /// The time of the last request made to an Oanda V20 service
      /// </summary>
      private DateTime m_LastRequestTime = DateTime.UtcNow;

      /// <summary>
      /// Oanda recommends that requests per Account are throttled to a maximium of 100 requests/second.
      /// http://developer.oanda.com/rest-live-v20/best-practices/
      /// </summary>
      private int RequestDelayMilliSeconds = 11;

      /// <summary>
      /// Gets the base uri of the target service
      /// </summary>
      /// <param name="server">The enurmeration for the target service</param>
      /// <returns>Returns the base uri of the target server</returns>
      private string ServerUri(EServer server)
      {
         return GetServer(server);
      }

      /// <summary>
      /// Determines if trading is halted for the provided instrument.
      /// </summary>
      /// <param name="symbol">Instrument to check if halted. Default is SPX.</param>
      /// <returns>True if trading is halted, false if trading is not halted.</returns>
      public async Task<bool> IsMarketHalted(string symbol = SecurityNames.ExchangeTradedFunds.SPDRSP500)
      {
         var symbols = new List<string>() { symbol };

         var quotes = await GetQuotesAsync(symbols);

         bool isTradeable = quotes.QuoteData[0].quoteStatus == QuoteStatus.RealTime;

         return !(isTradeable);
      }

      /// <summary>
      /// Sends a web request to a remote endpoint (uri).
      /// </summary>
      /// <typeparam name="T">The response type</typeparam>
      /// <param name="uri">The uri of the remote service</param>
      /// <param name="method">method for the request (defaults to GET)</param>
      /// <param name="requestParams">optional parameters (if provided, it's assumed the uri doesn't contain any)</param>
      /// <returns>A success response object of type T or a failure response object of type ErrorResponse</returns>
      private async Task<T> MakeRequestAsync<T>(string uri, string method = "GET", WebHeaderCollection headers = null, Dictionary<string, string> requestParams = null)
      {
         return await MakeRequestAsync<T, ErrorResponse>(uri, method, headers, requestParams);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="uri"></param>
      /// <param name="method"></param>
      /// <param name="headers"></param>
      /// <param name="requestParams"></param>
      /// <returns></returns>
      private async Task<ETrade10Response> MakeRequestAsync(string uri, string method = "GET", WebHeaderCollection headers = null, Dictionary<string, string> requestParams = null)
      {
         return await MakeRequestAsync<ETrade10Response, ErrorResponse>(uri, method, headers, requestParams);
      }

      /// <summary>
      /// Sends a web request to a remote service (uri).
      /// </summary>
      /// <typeparam name="T">The success response type</typeparam>
      /// <typeparam name="E">The error  response type</typeparam>
      /// <param name="uri">The uri of the remote service</param>
      /// <param name="method">The request verb for the request. Default is GET</param>
      /// <param name="requestParams">optional parameters (if provided, it's assumed the uri doesn't contain any)</param>
      /// <returns>A success response object of type T or a failure response object of type E</returns>
      private async Task<T> MakeRequestAsync<T, E>(string uri, string method = "GET", WebHeaderCollection headers = null, Dictionary<string, string> requestParams = null)
         where E : IErrorResponse
      {
         uri = _config.PreferJson ? uri += ".json" : uri;

         if (requestParams?.Count > 0)
         {
            string queryString = CreateQueryString(requestParams);
            uri = uri.TrimEnd('/') + "?" + queryString;
         }

         return await GetWebResponse<T, E>(CreateHttpRequest(uri, headers, method));
      }

      /// <summary>
      /// Sends a web request with a JSON body to a remote service (uri). 
      /// </summary>
      /// <typeparam name="T">The success response type</typeparam>
      /// <typeparam name="E">The error response type</typeparam>
      /// <param name="method">The request verb for the request</param>
      /// <param name="requestBody">The request body (must be a valid json string)</param>
      /// <param name="uri">The uri of the remote service</param>
      /// <returns>A success response object of type T or a failure response object of type E</returns>
      private async Task<T> MakeRequestWithJSONBody<T, E>(string method, string requestBody, string uri, WebHeaderCollection headers = null)
         where E : IErrorResponse
      {
         // Create the request
         var request = CreateHttpRequest(uri, headers, method);

         // Write the body
         using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
            await writer.WriteAsync(requestBody);

         return await GetWebResponse<T, E>(request);
      }

      /// <summary>
      /// Sends a web request with a JSON body to a remote service (uri).
      /// </summary>
      /// <typeparam name="T">The success response type</typeparam>
      /// <typeparam name="E">The error response type</typeparam>
      /// <typeparam name="P">The requestParams object type</typeparam>
      /// <param name="method">The request verb for the request</param>
      /// <param name="requestParams">the parameters to pass in the request body</param>
      /// <param name="uri">The uri of the remote service</param>
      /// <returns>A success response object of type T or a failure response object of type E</returns>
      private async Task<T> MakeRequestWithJSONBody<T, E, P>(string method, P requestParams, string uri, WebHeaderCollection headers = null)
         where E : IErrorResponse
      {
         string requestBody = CreateJSONBody(requestParams);

         return await MakeRequestWithJSONBody<T, E>(method, requestBody, uri);
      }
      #endregion

      #region response
      /// <summary>
      /// Sends an Http request to a remote service and returns the de-serialized response
      /// </summary>
      /// <typeparam name="T">>Type of the response returned by the remote service</typeparam>
      /// <typeparam name="E">>Type of the error response returned by the remote service</typeparam>
      /// <param name="request">The request sent to the remote service</param>
      /// <returns>A success response object of type T or a failure response object of type E</returns>
      private async Task<T> GetWebResponse<T, E>(HttpWebRequest request)
      {
         while (DateTime.UtcNow < m_LastRequestTime.AddMilliseconds(RequestDelayMilliSeconds))
         {
         }

         try
         {
            using (var response = await request.GetResponseAsync())
            {
               var stream = GetResponseStream(response);
               var reader = new StreamReader(stream);

               string contentType = response.Headers[HttpResponseHeader.ContentType];

               if (contentType.Equals(MediaTypeNames.Application.Json))
               {
                  string json = reader.ReadToEnd();
                  var result = JsonConvert.DeserializeObject<T>(json);
                  return result;
               }
               if (contentType.Equals(MediaTypeNames.Application.Xml))
               {
                  var result = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                  return result;
               }
               if (contentType.Equals(MediaTypeNames.Text.Html))
               {
                  var result = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                  return result;
               }
               throw new ArgumentException($"HttpResponseHeader.ContentType: {contentType} not supported.");
            }
         }
         catch (WebException ex)
         {
            string errorResult = GetErrorResponse<E>(ex);

            throw errorResult != "" ? new Exception(errorResult) : ex;
         }
         finally
         {
            m_LastRequestTime = DateTime.UtcNow;
         }
      }

      private string GetErrorResponse<E>(WebException ex)
      {
         var stream = GetResponseStream(ex.Response);
         var reader = new StreamReader(stream);
         string result = reader.ReadToEnd();

         string contentType = ex.Response.Headers[HttpResponseHeader.ContentType];

         if (contentType.Equals(MediaTypeNames.Application.Json))
         {
            // add a 'type' property for the ErrorResponseFactory
            dynamic error = JsonConvert.DeserializeObject(result);
            error.type = typeof(E).Name;

            return JsonConvert.SerializeObject(error);
         }
         if (contentType.Equals(MediaTypeNames.Text.Html))
         {
            // need to read the doc and get the error message
            return "";
         }

         return "";
      }

      /// <summary>
      /// Writes the response from the remote service to a text stream
      /// </summary>
      /// <param name="response">The response received from the remote service</param>
      /// <returns>A stream object. The stream may be a subclass (GZipStream or DeflateStream) if
      /// the response header indicates matched encoding.</returns>
      private Stream GetResponseStream(WebResponse response)
      {
         var stream = response.GetResponseStream();

         // handle a gzipped response
         if (response.Headers[HttpResponseHeader.ContentEncoding] == "gzip")
            stream = new GZipStream(stream, CompressionMode.Decompress);

         // handle a deflated response
         else if (response.Headers[HttpResponseHeader.ContentEncoding] == "deflate")
            stream = new DeflateStream(stream, CompressionMode.Decompress);

         return stream;
      }
      #endregion

      #region json
      /// <summary>
      /// Creates the request body as a JSON string
      /// </summary>
      /// <typeparam name="P">The type of the parameterObject</typeparam>
      /// <param name="parameterObject">The object containing the request body parameters</param>
      /// <param name="simpleDictionary">Indicates if the passed object is a Dictionary</param>
      /// <returns>A JSON string representing the request body</returns>
      private string CreateJSONBody<P>(P parameterObject, bool simpleDictionary = false)
      {
         // for parameters passed as dictionaries
         if (typeof(P).GetInterfaces().Contains(typeof(IDictionary)))
         {
            var settings = new DataContractJsonSerializerSettings
            {
               UseSimpleDictionaryFormat = true
            };

            var jsonSerializer = new DataContractJsonSerializer(typeof(P), settings);
            using (var ms = new MemoryStream())
            {
               jsonSerializer.WriteObject(ms, parameterObject);
               byte[] msBytes = ms.ToArray();
               return Encoding.UTF8.GetString(msBytes, 0, msBytes.Length);
            }
         }
         // for parameters passed as objects
         else
            return ConvertToJSON(parameterObject);
      }

      /// <summary>
      /// Serializes an object to a JSON string
      /// </summary>
      /// <param name="obj">The object to serialize</param>
      /// <param name="ignoreNulls">Indicates if null properties should be excluded from the JSON output</param>
      /// <returns>A JSON string representing the input object</returns>
      private string ConvertToJSON(object obj, bool ignoreNulls = true)
      {
         var nullHandling = ignoreNulls ? NullValueHandling.Ignore : NullValueHandling.Include;

         // oco: look into the DateFormatting
         // might be able to use DateTime instead of string in objects
         var settings = new JsonSerializerSettings()
         {
            TypeNameHandling = TypeNameHandling.None,
            NullValueHandling = nullHandling
         };

         string result = JsonConvert.SerializeObject(obj, settings);

         return result;
      }
      #endregion

      #region utilities
      /// <summary>
      /// Creates the request object string out of a dictionary of parameters
      /// </summary>
      /// <param name="uri">The uri of the remote service</param>
      /// <param name="method">The Http verb for the request</param>
      /// <returns>An HttpWebRequest object</returns>
      private HttpWebRequest CreateHttpRequest(string uri, WebHeaderCollection headers, string httpMethod)
      {
         var request = WebRequest.CreateHttp(uri);
         request.Headers.Add(headers ?? new WebHeaderCollection());

         if (string.IsNullOrEmpty(request.Headers[HttpRequestHeader.Authorization]))
         {
            var parameters = new Dictionary<string, string>()
            {
               { "oauth_token", Credentials.AccessToken.oauth_token },
               { "oauth_token_secret", Credentials.AccessToken.oauth_token_secret }
            };

            string authHeaderValue = OAuthSvc.GetOAuthHeaderValue(new HttpMethod(httpMethod), uri, parameters);
            request.Headers[HttpRequestHeader.Authorization] = $"OAuth {authHeaderValue}";
         }

         //request.Headers[HttpRequestHeader.ContentType] = "application/xml";
         //request.Headers[HttpRequestHeader.Accept] = "application/xml";
         request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";

         request.Method = httpMethod;

         return request;
      }

      /// <summary>
      /// Converts a list of strings into a comma-separated values list (csv)
      /// </summary>
      /// <param name="items">The list of strings to convert to csv</param>
      /// <returns>A csv string of the list items</returns>
      private string GetCommaSeparatedString(List<string> items)
      {
         var stringBuilder = new StringBuilder();
         foreach (string item in items)
         {
            if (!stringBuilder.ToString().Contains(item))
               stringBuilder.Append(item + ",");
         }
         return stringBuilder.ToString().Trim(',');
      }

      /// <summary>
      /// Creates a query string from a dictionary of parameters
      /// </summary>
      /// <param name="requestParams">The parameters dictionary to convert to a query string.</param>
      /// <returns>A query string</returns>
      private string CreateQueryString(Dictionary<string, string> requestParams)
      {
         string queryString = "";
         foreach (var pair in requestParams)
         {
            queryString += WebUtility.UrlEncode(pair.Key) + "=" + WebUtility.UrlEncode(pair.Value) + "&";
         }
         queryString = queryString.Trim('&');
         return queryString;
      }

      /// <summary>
      /// Converts an object into a dictionary of key-value pairs
      /// </summary>
      /// <param name="input">The object to convet to a dictionary</param>
      /// <returns>A Dictionary{string,string} object.</returns>
      public Dictionary<string, string> ConvertToDictionary(object input)
      {
         if (input == null)
            return null;

         string json = ConvertToJSON(input, true);

         return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
      }

      protected DateTime GetTokenExpirationTime()
      {
         return DateTime.UtcNow.AddHours(2.0);
      }
      #endregion

      #region enums

      public enum EServer
      {
         OAuth,
         Authorize,
         Accounts,
         Alerts,
         Market,
         PricingStream,
         TransactionsStream
      }

      public enum EEnvironment
      {
         Sandbox,
         Production
      }

      #endregion
   }
}
