using System.Collections.Generic;

namespace OkonkwoETrade10.Alerts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definitions/FailedAlerts
   /// </summary>
   public class FailedAlerts
   {
      /// <summary>
      /// The array of failed alert IDs
      /// </summary>
      public List<int> alertId { get; set; }
   }
}
