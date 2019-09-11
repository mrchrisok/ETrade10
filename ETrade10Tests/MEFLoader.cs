using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using OkonkwoETrade10.Authorization;

namespace ETrade10Tests
{
   public static class MEFLoader
   {
      static AggregateExportProvider m_Container;

      public static AggregateExportProvider Container
      {
         get
         {
            if (m_Container == null)
               m_Container = Init(null);

            return m_Container;
         }
      }

      public static AggregateExportProvider Init(ICollection<ComposablePartCatalog> partsCatalogs)
      {
         var clientCatalog = new AggregateCatalog();
         if (partsCatalogs != null)  // discover objects in passed in assembly catalog
            foreach (var part in partsCatalogs)
               clientCatalog.Catalogs.Add(part);

         var clientContainer = new CompositionContainer(clientCatalog, true);
         var coreContainer = GetCoreContainer();

         var aggregateExportProvider = new AggregateExportProvider(
              clientContainer, // exports in this container have precedence
              coreContainer);

         return aggregateExportProvider;
      }

      private static CompositionContainer GetCoreContainer()
      {
         var catalog = new AggregateCatalog();

         catalog.Catalogs.Add(new AssemblyCatalog(typeof(ETradeOAuth10).Assembly));

         var container = new CompositionContainer(catalog, true);

         return container;
      }
   }
}

