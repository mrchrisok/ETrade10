using OkonkwoETrade10.Common;

namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-transaction-v1.html#/definitions/Brokerage
   /// </summary>
   public class Brokerage
   {
      /// <summary>
      /// Type of transaction(deposit, dividend, and so on). 
      /// Possible values are listed in the Transaction types table below.
      /// </summary>
      public string transactionType { get; set; }

      /// <summary>
      /// The specific brokerage product
      /// </summary>
      public Product product { get; set; }

      /// <summary>
      /// Item count; for example, share count
      /// </summary>
      public decimal quantity { get; set; }

      /// <summary>
      /// Price per item if applicable; for example, price per share
      /// </summary>
      public decimal price { get; set; }

      /// <summary>
      /// Settlement currency
      /// </summary>
      public string settlementCurrency { get; set; }

      /// <summary>
      /// Payment currency
      /// </summary>
      public string paymentCurrency { get; set; }

      /// <summary>
      /// The brokerage fee
      /// </summary>
      public decimal fee { get; set; }

      /// <summary>
      /// The memo field
      /// </summary>
      public string memo { get; set; }

      /// <summary>
      /// The check number
      /// </summary>
      public string checkNo { get; set; }

      /// <summary>
      /// The order number
      /// </summary>
      public string orderNo { get; set; }
   }
}
