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

        // returns a list of available layouts
        [OperationContract]
        List<DTLayout> getLayouts();

        // adds a new rss resource.
        [OperationContract]
        void addRssSource(DTRssSource dtRssSource);

        // removes a current rss resource.
        [OperationContract]
        void removeRssSource(DTRssSource dtRssSource);

        // gets the rss resources.
        [OperationContract]
        DTRssSourcesCol listRssSources();

        // adds a new theme category.
        [OperationContract]
        void addThemeCategory(DTThemeCategoryMovAdmin dtThemeCategory);

        // removes a current theme category.
        [OperationContract]
        bool removeThemeCategory(DTThemeCategoryMovAdmin dtThemeCategory);

        // gets the theme categories.
        [OperationContract]
        DTThemeCategoriesColMovAdmin listThemeCategories();

        // returns all the data of the user.
        [OperationContract]
        DTUserDetails_MovAdmin getUserDetails(DTUser_MovAdmin dtUser);

        // returns all users.
        [OperationContract]
        DTUsersCol_MovAdmin getUsersListFull();
        
        // returns all users allowed.
        [OperationContract]
        DTUsersCol_MovAdmin getUsersListAllowed();

        // returns all users banned.
        [OperationContract]
        DTUsersCol_MovAdmin getUsersListBanned();

        // bans a user.
        [OperationContract]
        void banUser(DTUser_MovAdmin user);

        // reallows a user.
        [OperationContract]
        void reallowUser(DTUser_MovAdmin user);

        // returns all resources.
        [OperationContract]
        DTResourcesCol_MovAdmin getResourcesListAll();

        // returns all resources enabled.
        [OperationContract]
        DTResourcesCol_MovAdmin getResourcesListEnabled();

        // returns all resources disabled.
        [OperationContract]
        DTResourcesCol_MovAdmin getResourcesListDisabled();

        // bans a resource.
        [OperationContract]
        void enableResource(DTResource_MovAdmin resource);

        // reallows a resource.
        [OperationContract]
        void disableResource(DTResource_MovAdmin resource);

        // returns a users register report.
        [OperationContract]
        DTUsersRegisterReport getUsersRegisterReport(DTUsersRegisterReport dtUserReport);
    }
}
