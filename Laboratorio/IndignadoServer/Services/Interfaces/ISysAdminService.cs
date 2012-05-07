using System.ServiceModel;

namespace IndignadoServer.Services
{
    // ISysAdminService defines all the services of the SysAdmin subsystem.

    [ServiceContract]
    public interface ISysAdminService
    {
        // creates a movement.
        [OperationContract]
        void createMovement (DTMovement dtMovement);
        
        // returns all movements.
        [OperationContract]
        DTMovementsCol getMovementsList();

        [OperationContract]
        void enableMovement();

        [OperationContract]
        void disableMovement();
    }
}
