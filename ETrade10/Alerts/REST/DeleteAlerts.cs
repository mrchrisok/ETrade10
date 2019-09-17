using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Alerts;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API deletes a list of alerts.
      /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definition/deleteAlert
      /// </summary>
      /// <param name="alertIdList">Comma separated alertId list</param>
      /// <returns>Success or failure. If a failure, returns a list of failed alert Ids.</returns>
      public async Task<DeleteAlertsResponse> DeleteAlertsAsync(List<long> alertIdList)
      {
         var alertIdLongList = alertIdList.ConvertAll(id => id.ToString());

         string uri = ServerUri(EServer.Alerts) + $"{GetCommaSeparatedString(alertIdLongList)}";

         var response = await MakeRequestAsync<DeleteAlertsResponse, DeleteAlertsErrorResponse>(uri, "DELETE");

         return response;
      }
   }

   /// <summary>
   /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definitions/DeleteAlertsResponse
   /// </summary>
   public class DeleteAlertsResponse : Response
   {
      /// <summary>
      /// The result status of the alert
      /// </summary>
      public string result { get; set; }

      /// <summary>
      /// The failed alerts response
      /// </summary>
      public FailedAlerts failedAlerts { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class DeleteAlertsErrorResponse : ErrorResponse
   {
   }
}
