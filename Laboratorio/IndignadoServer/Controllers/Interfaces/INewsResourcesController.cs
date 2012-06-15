using System.Collections.ObjectModel;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface INewsResourcesController
    {
        // returns all rss items.
        Collection<DTRssItem> getNewsList();

        // returns all resources.
        DTResourcesCol_NewsResources getResourcesList(int pageNumber);

        // returns the top ranked resources.
        DTResourcesCol_NewsResources getResourcesListTopRanked(int pageNumber);

        // returns all resources published by the given user.
        DTResourcesCol_NewsResources getResourcesListUser(Usuario user, int pageNumber);

        // returns all the data of the user.
        Usuario getUser(Usuario user);

        // creates a resource.
        void createResource(Recurso resource);
        
        // gets resource data from the link.
        Recurso getResourceData(string link);
        
        // likes a resource.
        void likeResource(Recurso resource);

        // unlikes a resource.
        void unlikeResource(Recurso resource);

        // mark a resource as inappropriate.
        void markResourceInappropriate(Recurso resource);
        
        // unmark a resource as inappropriate.
        void unmarkResourceInappropriate(Recurso resource);
    }
}
