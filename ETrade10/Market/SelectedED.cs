namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-market-v1.html#/definitions/SelectedED
   /// </summary>
   public class SelectedED
   {
      /// <summary>
      /// The selected month	
      /// </summary>
      public int month { get; set; }

      /// <summary>
      /// The selected year	
      /// </summary>
      public int year { get; set; }

      /// <summary>
      /// The selected day
      /// </summary>
      public int day { get; set; }
   }
}
