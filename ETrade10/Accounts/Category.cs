namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-transaction-v1.html#/definitions/Category
   /// </summary>
   public class Category
   {
      /// <summary>
      /// The category ID
      /// </summary>
      public string categoryId { get; set; }

      /// <summary>
      /// The parent ID
      /// </summary>
      public string parentId { get; set; }

      /// <summary>
      /// The category name
      /// </summary>
      public string categoryName { get; set; }

      /// <summary>
      /// The parent category name
      /// </summary>
      public string parentName { get; set; }
   }
}
