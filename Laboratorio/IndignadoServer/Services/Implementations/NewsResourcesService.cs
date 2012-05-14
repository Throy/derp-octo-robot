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
        public DTResourcesCol getResourcesList()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getINewsResourcesController().getResourcesList();

            // create new resources datatypes collection.
            DTResourcesCol dtResourcesCol = new DTResourcesCol();
            dtResourcesCol.items = new Collection<DTResource>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT(resource));
            }

            // add a sample resource
            DTResource dtResource = new DTResource();
            dtResource.id = 0;
            dtResource.idUser = 1;
            dtResource.title = "Autito";
            dtResource.description = "el juego revolucionarazo";
            dtResource.urlLink = "autito.tk";
            dtResource.urlThumb = "logo_autito.gif";
            dtResource.date = new System.DateTime (2012, 05, 24, 20, 38, 0);
            dtResource.numberLikes = 38;
            dtResourcesCol.items.Add(dtResource);

            // return the collection.
            return dtResourcesCol;
        }

        // creates a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void createResource (DTResource dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().createResource (DTToClass.DTToResource (dtResource));
        }

        // geta resource data from the link.
        public DTResource getResourceData(string link)
        {
            return ClassToDT.ResourceToDT(ControllersHub.Instance.getINewsResourcesController().getResourceData(link));
        }

        // likes a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void likeResource(DTResource dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().likeResource(DTToClass.DTToResource(dtResource));
        }

        // unlikes a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void unlikeResource(DTResource dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().unlikeResource(DTToClass.DTToResource(dtResource));
        }
    }
}
