using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer.Services
{
    // ISysAdminService defines all the services of the SysAdmin subsystem.

    [ServiceContract]
    public interface ISysAdminService
    {
        // creates a meeting
        [OperationContract]
        void createMovement (DTMovement dtMovement);

        [OperationContract]
        void setMovement();
        
        // returns all movements
        [OperationContract]
        DTMovementsCol getMovementsList();

        [OperationContract]
        void enableMovement();

        [OperationContract]
        void disableMovement();
    }
}
