using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using IndignadoServer.Services;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISessionService" in both code and config file together.
    [ServiceContract]
    public interface ISessionService
    {
        [FaultContract(typeof(LoginFault))]
        [OperationContract]
        DTLoginInfo Login(int idMovmiento, String userName, String password);

        [FaultContract(typeof(LoginFault))]
        [OperationContract]
        DTLoginInfo LoginFB(int idMovimiento, String accesToken);

        [OperationContract]
        DTUserCreateStatus RegisterUser(DTRegisterModel user);

        [OperationContract]
        DTUserCreateStatus RegisterFBUser(DTRegisterFBModel user);

        [OperationContract]
        bool ValidateToken(int idMovmiento, String token);

        [OperationContract]
        DTTenantInfo GetTenantInfo(String movimiento);
        

        // checks that the client is a registered user.
        [OperationContract]
        bool ValidateRegUser();

        // checks that the client is a movement admin.
        [OperationContract]
        bool ValidateMovAdmin();

        // checks that the client is a system admin.
        [OperationContract]
        bool ValidateSysAdmin();
    }
}
