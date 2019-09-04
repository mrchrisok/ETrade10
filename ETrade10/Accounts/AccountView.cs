namespace OkonkwoETrade10.Accounts
{
   public abstract class AccountView
   {
      /// <summary>
      /// The last trade
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// The time of the last trade
      /// </summary>
      public long lastTradeTime { get; set; }

      /// <summary>
      /// The quote type REALTIME, DELAYED, CLOSING, EH_REALTIME, EH_BEFORE_OPEN, EH_CLOSED
      /// </summary>
      public string quoteStatus { get; set; }
   }
}
