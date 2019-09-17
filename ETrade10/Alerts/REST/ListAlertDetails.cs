using System.Threading.Tasks;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API provides details for an alert.
      /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definition/getAlertDetails
      /// <param name="id">The alert details parameters</param>
      /// <param name="parameters">The alert details parameters</param>
      /// <returns>An AlertDetailsResponse object</returns>
      public async Task<AlertDetailsResponse> ListAlertDetailsAsync(long id, AlertDetailsParameters parameters)
      {
         string uri = ServerUri(EServer.Alerts) + $"{id}";

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<AlertDetailsResponse, AlertDetailsErrorResponse>(uri, requestParams: requestParams);

         return response;
      }

      public class AlertDetailsParameters
      {
         /// <summary>
         /// The HTML tags on the alert. By default it is false. 
         /// If set to true, it returns the alert details msgText with html tags.
         /// </summary>
         public bool htmlTags { get; set; }
      }
   }

   /// <summary>
   /// The GET success response
   /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definitions/AlertDetailsResponse
   /// </summary>
   public class AlertDetailsResponse : Response
   {
      /// <summary>
      /// The numeric private readonly alert ID
      /// </summary>
      public long id { get; set; }

      /// <summary>
      /// The date and time the alert was issued, in Epoch time
      /// </summary>
      public long createTime { get; set; }

      /// <summary>
      ///  The subject of the alert
      /// </summary>
      public string subject { get; set; }

      /// <summary>
      /// The text of the alert message
      /// </summary>
      public string msgText { get; set; }

      /// <summary>
      /// The time the alert was read
      /// </summary>
      public long readTime { get; set; }

      /// <summary>
      /// The time the alert was deleted
      /// </summary>
      public long deleteTime { get; set; }

      /// <summary>
      /// The market symbol for the instrument related to this alert, if any; for example, GOOG.
      /// It is set only  ma ldeicinlci bupcase of Stock alerts.
      /// </summary>
      public string symbol { get; set; }

      /// <summary>
      /// Contains url for next alert
      /// </summary>
      public string next { get; set; }

      /// <summary>
      /// Contains url for previous alert
      /// </summary>
      public string prev { get; set; }
   }

   /// <summary>
   /// The GET error response
   /// </summary>
   public class AlertDetailsErrorResponse : ErrorResponse
   {
   }
}
