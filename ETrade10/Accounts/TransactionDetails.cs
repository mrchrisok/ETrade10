namespace OkonkwoETrade10.Accounts
{
   public class TransactionDetails
   {
      public long transactionId { get; set; }
      public string accountId { get; set; }
      public long transactionDate { get; set; }
      public decimal amount { get; set; }
      public string description { get; set; }
      public Category category { get; set; }
      public Brokerage brokerage { get; set; }
   }
}
