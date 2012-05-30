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
        // gets the user's movement.
        [OperationContract]
        DTMovement getMovement();

        // returns all theme categories.
        [OperationContract]
        DTThemeCategoriesColUsers getThemeCategoriesList();
        
        // get interested in a theme category.
        [OperationContract]
        void getInterestedThemeCategory(DTThemeCategoryUsers dtThemeCategory);
        
        // get uninterested in a theme category.
        [OperationContract]
        void getUninterestedThemeCategory(DTThemeCategoryUsers dtThemeCategory);

        // returns the data of the user.
        [OperationContract]
        DTUser_Users getUser();

        // updates the data of the user.
        [OperationContract]
        void setUser(DTUser_Users dtUser);
    }
}
