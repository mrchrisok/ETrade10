namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-balance-v1.html#/definitions/RealTimeValues
   /// </summary>
   public class RealTimeValues
   {
      /// <summary>
      /// The total account value	
      /// </summary>
      public decimal totalAccountValue;

      /// <summary>
      /// The net market value
      /// </summary>
      public decimal netMv;

      /// <summary>
      /// The long net market value
      /// </summary>
      public decimal netMvLong;

      /// <summary>
      /// The short net market value
      /// </summary>
      public decimal netMvShort;

      /// <summary>
      /// The total long value
      /// </summary>
      public decimal totalLongValue;
   }
}
