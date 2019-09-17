using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Reflection;
using OkonkwoETrade10.Authorization;

namespace ETrade10Tests
{
   public static class MEFLoader
   {
      private static CompositionHost m_Container;

      public static CompositionHost Container
      {
         get
         {
            if (m_Container == null)
               m_Container = Init(null);

            return m_Container;
         }
      }

      public static CompositionHost Init(IEnumerable<Assembly> clientAssemblies)
      {
         var configuration = new ContainerConfiguration();

         foreach (var coreType in GetCoreTypes())
            configuration.WithPart(coreType);

         if (clientAssemblies != null)
            foreach (var clientAssembly in clientAssemblies)
               foreach (var clientType in clientAssembly.GetTypes())
                  configuration.WithPart(clientType);

         return configuration.CreateContainer();
      }

      private static Type[] GetCoreTypes()
      {
         var coreTypes = new List<Type>();

         coreTypes.AddRange(typeof(ETradeOAuth10).Assembly.GetTypes());

         return coreTypes.ToArray();
      }
   }
}

