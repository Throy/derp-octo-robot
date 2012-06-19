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
            DTRssItemsCol dtRssItemsCol = new DTRssItemsCol();
            dtRssItemsCol.items = ControllersHub.Instance.getINewsResourcesController().getNewsList();
            return dtRssItemsCol;
        }

        // returns all resources.
        public DTResourcesCol_NewsResources getResourcesList(int pageNumber)
        {
            // get resources datatypes.
            return ControllersHub.Instance.getINewsResourcesController().getResourcesList(pageNumber);
        }

        // returns the top ranked resources.
        public DTResourcesCol_NewsResources getResourcesListTopRanked(int pageNumber)
        {
            // get resources datatypes.
            return ControllersHub.Instance.getINewsResourcesController().getResourcesListTopRanked( pageNumber);
        }

        // returns all the data of the user.
        public DTUserDetails_NewsResources getUserDetails(DTUser_NewsResources dtUser, int pageNumber)
        {
            // create user details
            DTUserDetails_NewsResources userDetails = new DTUserDetails_NewsResources();
            userDetails.user = ClassToDT.UserToDT_NewsResources(ControllersHub.Instance.getINewsResourcesController().getUser(DTToClass.DTToUser(dtUser)));
            userDetails.resources  = ControllersHub.Instance.getINewsResourcesController().getResourcesListUser(DTToClass.DTToUser(dtUser), pageNumber);

            // return the datatype.
            return userDetails;
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

        // removes a resource by the user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void removeResource(DTResource_NewsResources dtResource)
        {
            ControllersHub.Instance.getINewsResourcesController().removeResource(DTToClass.DTToResource(dtResource));
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
