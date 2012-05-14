using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer.Services
{
    [ServiceContract]
    public interface IUsersService
    {
        // returns all theme categories.
        [OperationContract]
        DTThemeCategoriesColUsers getThemeCategoriesList();
    }
}
