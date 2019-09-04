using System.Collections.Generic;
using OkonkwoETrade10.Order;

namespace OkonkwoETrade10.Framework.Factories
{
   public class OrderFactory
   {
      public static List<IOrder> Create(IEnumerable<IOrder> data)
      {
         var orders = new List<IOrder>();

         foreach (var order in data)
         {
            orders.Add(Create(order.orderType));
         }

         return orders;
      }

      public static IOrder Create(string orderType)
      {
         IOrder order;

         switch (orderType)
         {
            case OrderType.Equity: order = new Order.Order(); break;
            case OrderType.Option: order = new Order.Order(); break;
            case OrderType.Spreads: order = new Order.Order(); break;
            case OrderType.BuyWrites: order = new Order.Order(); break;
            case OrderType.Butterfly: order = new Order.Order(); break;
            case OrderType.IronButterfly: order = new Order.Order(); break;
            case OrderType.Condor: order = new Order.Order(); break;
            case OrderType.IronCondor: order = new Order.Order(); break;
            case OrderType.MutualFund: order = new Order.Order(); break;
            case OrderType.MoneyMarketFund: order = new Order.Order(); break;
            case OrderType.Bond: order = new Order.Order(); break;
            case OrderType.Contingent: order = new Order.Order(); break;
            case OrderType.OneCancelsAll: order = new Order.Order(); break;
            case OrderType.OneTriggersAll: order = new Order.Order(); break;
            case OrderType.OneTriggesOneCancelsOther: order = new Order.Order(); break;
            case OrderType.OptionExercise: order = new Order.Order(); break;
            case OrderType.OptionAssignment: order = new Order.Order(); break;
            case OrderType.OptionExpired: order = new Order.Order(); break;
            case OrderType.DoNotExercise: order = new Order.Order(); break;
            case OrderType.Bracketed: order = new Order.Order(); break;

            default: order = new Order.Order(); break;
         }

         order.orderType = orderType;

         return order;
      }
   }
}
