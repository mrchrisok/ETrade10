namespace OkonkwoETrade10.Alerts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/user/api-alert-v1.html#/definitions/Alert
   /// </summary>
   public class Alert
   {
      /// <summary>
      /// The numeric alert ID
      /// </summary>
      public long id { get; set; }

      /// <summary>
      /// The date and time the alert was issued, in Epoch time
      /// </summary>
      public long createTime { get; set; }

      /// <summary>
      /// The subject of the alert
      /// </summary>
      public string subject { get; set; }

      /// <summary>
      /// The current status of the alert UNREAD, READ, DELETED, UNDELETED
      /// </summary>
      public string status { get; set; }
   }
}
