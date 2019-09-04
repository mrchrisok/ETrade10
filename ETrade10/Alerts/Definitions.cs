/// <summary>
/// http://developer.oanda.com/rest-live-v20/account-df/
/// </summary>
namespace OkonkwoETrade10.Alerts
{
   public class AlertCategory
   {
      public const string Stock = "STOCK";
      public const string Account = "ACCOUNT";
   }

   public class AlertStatus
   {
      public const string Unread = "UNREAD";
      public const string Read = "READ";
      public const string Deleted = "DELETED";
      public const string Undeleted = "UNDELETED";
   }
   public class DeleteAlertsResult
   {
      public const string Success = "SUCCESS";
      public const string Error = "ERROR";
   }
}
