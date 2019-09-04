using System;
using Newtonsoft.Json;

namespace OkonkwoETrade10.Framework.JsonConverters
{
   public class TransactionConverter : JsonConverterBase
   {
      public override bool CanConvert(Type objectType)
      {
         //return objectType == typeof(ITransaction);

         return true;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         //var jsonToken = JToken.Load(reader);

         //if (jsonToken.Type == JTokenType.Array)
         //{
         //   var transactions = new List<ITransaction>();

         //   var jsonArray = (JArray)jsonToken;

         //   foreach (var item in jsonArray)
         //   {
         //      var transaction = TransactionFactory.Create(item["type"].Value<string>());
         //      serializer.Populate(item.CreateReader(), transaction);
         //      transactions.Add(transaction);
         //   }

         //   return transactions;
         //}
         //else if (jsonToken.Type == JTokenType.Object)
         //{
         //   ITransaction transaction = TransactionFactory.Create(jsonToken["type"].Value<string>());
         //   serializer.Populate(jsonToken.CreateReader(), transaction);
         //   return transaction;
         //}
         //else
         //   throw new ArgumentException(string.Format("Unexpected JTokenType ({0}) in reader.", jsonToken.Type.ToString()));

         return "";
      }
   }
}
