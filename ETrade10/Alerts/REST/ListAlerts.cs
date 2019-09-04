using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Alerts;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API provides a list of alerts.
      /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definition/getAlertsInbox
      /// </summary>
      /// <param name="parameters">The alerts list parameters</param>
      /// <returns>An AlertsResponse object</returns>
      public static async Task<AlertsResponse> ListAlertsAsync(AlertsParameters parameters)
      {
         string uri = ServerUri(EServer.Alerts);

         var requestParams = ConvertToDictionary(parameters);

         var response = await MakeRequestAsync<AlertsResponse, AlertsErrorResponse>(uri, requestParams: requestParams);

         return response;
      }

      public class AlertsParameters
      {
         /// <summary>
         /// The alert count.By default it returns 25. Max values that can be returned: 300.
         /// </summary>
         public short? count { get; set; }
         /// <summary>
         /// The alert category. By default it will return STOCK and ACCOUNT.STOCK, ACCOUNT
         /// </summary>
         public string category { get; set; }

         /// <summary>
         /// The alert status.By default it will return READ and UNREAD.READ, UNREAD, DELETED
         /// </summary>
         public string status { get; set; }

         /// <summary>
         /// Sorting is done based on the createDate ASC, DESC
         /// </summary>
         public string direction { get; set; }

         /// <summary>
         /// The alert search.Search is done based on the subject.
         /// </summary>
         public string search { get; set; }
      }
   }

   /// <summary>
   /// The GET success response
   /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definitions/AlertsResponse
   /// </summary>
   public class AlertsResponse : Response
   {
      /// <summary>
      /// The total number of alerts for the user including READ, UNREAD and DELETED
      /// </summary>
      public long totalAlerts { get; set; }

      /// <summary>
      /// The array of alert responses
      /// </summary>
      public List<Alert> alerts { get; set; }
   }

   /// <summary>
   /// The GET error response received from the accounts/accountID
   /// </summary>
   public class AlertsErrorResponse : ErrorResponse
   {
   }
}
