using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;
using RssToolkit.Rss;

namespace IndignadoServer.Controllers
{
    interface INewsResourcesController
    {
        // returns all rss items.
        Collection<RssItem> getNewsList();

        // returns all resources.
        Collection<Recurso> getResourcesList();

        // creates a resource.
        void createResource(Recurso resource);
        
        // gets resource data from the link.
        Recurso getResourceData(string link);
        
        // likes a resource.
        void likeResource(Recurso resource);

        // unlikes a resource.
        void unlikeResource(Recurso resource);
    }
}
