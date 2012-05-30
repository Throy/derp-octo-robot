using System.Collections.ObjectModel;
using System.Security.Permissions;
using RssToolkit.Rss;
using IndignadoServer.Controllers;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResorceService" in both code and config file together.
    public class NewsResourcesService : INewsResourcesService
    {
        // returns all rss items.
        public DTRssItemsCol getNewsList()
        {
            // get rss items datatypes.
            Collection<RssItem> rssItemsCol = ControllersHub.Instance.getINewsResourcesController().getNewsList();

            // create new rss items datatypes collection.
            DTRssItemsCol dtRssItemsCol = new DTRssItemsCol();
            dtRssItemsCol.items = new Collection<DTRssItem>();

            // add rss items to the datatypes collection.
            foreach (RssItem rssItem in rssItemsCol)
            {
                dtRssItemsCol.items.Add(ClassToDT.RssItemToDT(rssItem));
            }

            // return the collection.
            return dtRssItemsCol;
        }

        // returns all resources.
        public DTResourcesCol_NewsResources getResourcesList()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getINewsResourcesController().getResourcesList();

            // create new resources datatypes collection.
            DTResourcesCol_NewsResources dtResourcesCol = new DTResourcesCol_NewsResources();
            dtResourcesCol.items = new Collection<DTResource_NewsResources>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT_NewsResources(resource));
            }

            // return the collection.
            return dtResourcesCol;
        }

        // returns the top ranked resources.
        public DTResourcesCol_NewsResources getResourcesListTopRanked()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getINewsResourcesController().getResourcesListTopRanked();

            // create new resources datatypes collection.
            DTResourcesCol_NewsResources dtResourcesCol = new DTResourcesCol_NewsResources();
            dtResourcesCol.items = new Collection<DTResource_NewsResources>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT_NewsResources(resource));
            }

            // return the collection.
            return dtResourcesCol;
        }

        // creates a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void createResource (DTResource_NewsResources dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().createResource (DTToClass.DTToResource (dtResource));
        }

        // geta resource data from the link.
        public DTResource_NewsResources getResourceData(string link)
        {
            return ClassToDT.ResourceToDT_NewsResources(ControllersHub.Instance.getINewsResourcesController().getResourceData(link));
        }

        // likes a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void likeResource(DTResource_NewsResources dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().likeResource(DTToClass.DTToResource(dtResource));
        }

        // unlikes a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void unlikeResource(DTResource_NewsResources dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().unlikeResource(DTToClass.DTToResource(dtResource));
        }

        // mark a resource as inappropriate.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void markResourceInappropriate(DTResource_NewsResources dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().markResourceInappropriate(DTToClass.DTToResource(dtResource));
        }
        
        // unmark a resource as inappropriate.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void unmarkResourceInappropriate(DTResource_NewsResources dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().unmarkResourceInappropriate(DTToClass.DTToResource(dtResource));
        }
    }
}
