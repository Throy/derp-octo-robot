using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISessionService" in both code and config file together.
    [ServiceContract]
    public interface ISessionService
    {
        [OperationContract]
        String Login(int idMovmiento, String userName, String password);
    }
}
