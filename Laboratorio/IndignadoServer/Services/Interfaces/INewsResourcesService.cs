using System.ServiceModel;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResorceService" in both code and config file together.
    [ServiceContract]
    public interface INewsResourcesService
    {
        // returns all meetings
        [OperationContract]
        void getResourcesList();
    }
}
