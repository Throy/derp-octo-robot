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
        DTResourcesCol getResourcesList();

        // creates a resource.
        [OperationContract]
        void createResource (DTResource dtResource);

        // gets resource data from the link.
        [OperationContract]
        DTResource getResourceData(string link);

        // likes a resource.
        [OperationContract]
        void likeResource(DTResource dtResource);

        // unlikes a resource.
        [OperationContract]
        void unlikeResource(DTResource dtResource);
    }
}
