namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-account-v1.html#/definitions/Account
   /// </summary>
   public class Account
   {
      public int instNo { get; set; }
      public string accountId { get; set; }
      public string accountIdKey { get; set; }
      public string accountMode { get; set; }
      public string accountDesc { get; set; }
      public string accountName { get; set; }
      public string accountType { get; set; }
      public string institutionType { get; set; }
      public string accountStatus { get; set; }
      public long closedDate { get; set; }
   }
}
