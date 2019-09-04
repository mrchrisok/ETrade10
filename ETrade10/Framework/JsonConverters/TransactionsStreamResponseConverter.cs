using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using OkonkwoETrade10.REST.Streaming;

namespace OkonkwoETrade10.Framework.JsonConverters
{
   public class TransactionsStreamResponseConverter : JsonConverterBase
   {
      public override bool CanConvert(Type objectType)
      {
         bool canConvert = objectType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IStreamResponse));
         return canConvert;
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         //var response = new TransactionsStreamResponse();

         //var jsonToken = JToken.Load(reader);

         //if (jsonToken.Type == JTokenType.Object)
         //{
         //   bool isHeartbeat = jsonToken["type"].Value<string>() == "HEARTBEAT";

         //   if (isHeartbeat)
         //   {
         //      var heartbeat = new TransactionsHeartbeat();
         //      serializer.Populate(jsonToken.CreateReader(), heartbeat);
         //      response.heartbeat = heartbeat;
         //   }
         //   else
         //   {
         //      ITransaction transaction = TransactionFactory.Create(jsonToken["type"].Value<string>());
         //      serializer.Populate(jsonToken.CreateReader(), transaction);
         //      response.transaction = transaction;
         //   }

         //   return response;
         //}
         //else
         //   throw new ArgumentException(string.Format("Unexpected JTokenType ({0}) in reader.", jsonToken.Type.ToString()));

         return "";
      }
   }
}
