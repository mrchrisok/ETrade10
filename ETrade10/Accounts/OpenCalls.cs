namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-balance-v1.html#/definitions/OpenCalls
   /// </summary>
   public class OpenCalls 
   {
      /// <summary>
      /// The minimum equity call
      /// </summary>
      public decimal minEquityCall { get; set; }

      /// <summary>
      /// The federal call
      /// </summary>
      public decimal fedCall { get; set; }

      /// <summary>
      /// The cash call
      /// </summary>
      public decimal cashCall { get; set; }

      /// <summary>
      /// The house call
      /// </summary>
      public decimal houseCall { get; set; }
   }
}
