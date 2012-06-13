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
        DTResourcesCol_NewsResources getResourcesList();

        // returns the top ranked resources.
        [OperationContract]
        DTResourcesCol_NewsResources getResourcesListTopRanked();
        
        // returns all the data of the user.
        [OperationContract]
        DTUserDetails_NewsResources getUserDetails(DTUser_NewsResources dtUser);

        // creates a resource.
        [OperationContract]
        void createResource (DTResource_NewsResources dtResource);

        // gets resource data from the link.
        [OperationContract]
        DTResource_NewsResources getResourceData(string link);

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
