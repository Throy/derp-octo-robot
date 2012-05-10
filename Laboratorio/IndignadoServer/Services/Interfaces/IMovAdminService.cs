using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovAdmin" in both code and config file together.
    [ServiceContract]
    public interface IMovAdminService
    {
        // gets the admin's movement.
        [OperationContract]
        DTMovement getMovement();

        // changes the configuration of the movement.
        [OperationContract]
        void setMovement(DTMovement dtMovement);

        [OperationContract]
        void addRssSource(DTRssSource dtRssSource);

        [OperationContract]
        void removeRssSource(DTRssSource dtRssSource);

        [OperationContract]
        DTRssSourcesCol listRssSources(); 
    }
}
