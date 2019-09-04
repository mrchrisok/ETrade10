namespace OkonkwoETrade10.Accounts
{
   public class Cash
   {
      /// <summary>
      /// The funds reserved for open orders
      /// </summary>
      public decimal fundsForOpenOrdersCash { get; set; }

      /// <summary>
      /// The current cash balance of the money market or sweep deposit account
      /// </summary>
      public decimal moneyMktBalance { get; set; }
   }
}
