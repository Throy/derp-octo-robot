using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Permissions;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string PingPublic(string name);

        [OperationContract]
        string PingUsers(string name);

        [OperationContract]
        string PingMovAdmin(string name);

        [OperationContract]
        string PingSysAdmin(string name);
    }
}
