using System.ServiceModel;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResorceService" in both code and config file together.
    [ServiceContract]
    public interface INewsResourcesService
    {
        // returns all rss items.
        [OperationContract]
        DTRssItemsCol getNewsList();

        // returns all resources.
        [OperationContract]
        DTResourcesCol_NewsResources getResourcesList(int pageNumber);

        // returns the top ranked resources.
        [OperationContract]
        DTResourcesCol_NewsResources getResourcesListTopRanked(int pageNumber);

        // returns all resources published by the movement admin.
        [OperationContract]
        DTResourcesCol_NewsResources getResourcesListMovAdmin(int pageNumber);
        
        // returns all the data of the user.
        [OperationContract]
        DTUserDetails_NewsResources getUserDetails(DTUser_NewsResources dtUser, int pageNumber);

        // creates a resource.
        [OperationContract]
        void createResource (DTResource_NewsResources dtResource);

        // gets resource data from the link.
        [OperationContract]
        DTResource_NewsResources getResourceData(string link);

        // removes a resource by the user.
        [OperationContract]
        void removeResource(DTResource_NewsResources dtResource);

        // likes a resource.
        [OperationContract]
        void likeResource(DTResource_NewsResources dtResource);

        // unlikes a resource.
        [OperationContract]
        void unlikeResource(DTResource_NewsResources dtResource);

        // mark a resource as inappropriate.
        [OperationContract]
        void markResourceInappropriate(DTResource_NewsResources resource);

        // unmark a resource as inappropriate.
        [OperationContract]
        void unmarkResourceInappropriate(DTResource_NewsResources resource);
    }
}
