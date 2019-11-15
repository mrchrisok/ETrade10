namespace OkonkwoETrade10.Accounts
{
   public class Transaction
   {
      public long postDate { get; set; }
      public string description2 { get; set; }
      public string transactionType { get; set; }
      public string memo { get; set; }
      public bool imageFlag { get; set; }
      public string instType { get; set; }
      public string detailsURI { get; set; }

      // formerly inherited from TransactionDetail
      public long transactionId { get; set; }
      public string accountId { get; set; }
      public long transactionDate { get; set; }
      public decimal amount { get; set; }
      public string description { get; set; }
      //public Category category { get; set; }
      public Brokerage brokerage { get; set; }
   }
}
