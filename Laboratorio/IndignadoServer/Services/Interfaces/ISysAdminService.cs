using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISysAdminService" in both code and config file together.
    [ServiceContract]
    public interface ISysAdminService
    {
        [OperationContract]
        void createMovement();

        [OperationContract]
        void setMovement();

        [OperationContract]
        void enableMovement();

        [OperationContract]
        void disableMovement();
    }
}
