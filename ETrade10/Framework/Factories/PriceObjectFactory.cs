namespace OkonkwoETrade10.Framework.Factories
{
   public class PriceObjectFactory
   {
      public static IHasPrices Create(string type)
      {
         IHasPrices priceObject;

         switch (type)
         {
            case "OkonkwoETrade10.Transaction.TakeProfitDetails":
            //priceObject = new TakeProfitDetails(); break;
            case "OkonkwoETrade10.Transaction.StopLossDetails":
            //priceObject = new StopLossDetails(); break;
            case "OkonkwoETrade10.Transaction.TrailingStopLossDetails":
            //priceObject = new TrailingStopLossDetails(); break;
            default: priceObject = null; break;
         }

         return priceObject;
      }
   }
}
