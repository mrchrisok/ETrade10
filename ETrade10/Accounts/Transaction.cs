namespace OkonkwoETrade10.Accounts
{
   public class Transaction : TransactionDetails
   {
      public long postDate { get; set; }
      public string description2 { get; set; }
      public string transactionType { get; set; }
      public string memo { get; set; }
      public bool imageFlag { get; set; }
      public string instType { get; set; }
      public string detailsURI { get; set; }
   }
}
