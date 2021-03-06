﻿using System;
using System.Collections.ObjectModel;
using System.Security.Permissions;
using IndignadoServer.Controllers;
using IndignadoServer.LinqDataContext;
using System.Collections.Generic;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovAdmin" in both code and config file together.
    public class MovAdminService : IMovAdminService
    {
        // gets the admin's movement.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTMovement getMovement()
        {
            try
            {
                return ClassToDT.MovementToDT(ControllersHub.Instance.getIMovAdminController().getMovement());
            }
            catch
            {
                return null;
            }
        }

        // changes the configuration of the movement.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void setMovement(DTMovement dtMovement)
        {
            ControllersHub.Instance.getIMovAdminController().setMovement(DTToClass.DTToMovement(dtMovement));
        }

        // returns a list of available layouts
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public List<DTLayout> getLayouts()
        {
            return ControllersHub.Instance.getIMovAdminController().getLayouts();
        }

        // adds a new rss resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void addRssSource(DTRssSource dtRssSource){
            ControllersHub.Instance.getIMovAdminController().addRssSource(DTToClass.DTToRssSource(dtRssSource));
        }

        // removes a current rss resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void removeRssSource(DTRssSource dtRssSource){
            ControllersHub.Instance.getIMovAdminController().removeRssSource(DTToClass.DTToRssSource(dtRssSource));
        }

        // gets the rss resources.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTRssSourcesCol listRssSources(){
            return ControllersHub.Instance.getIMovAdminController().listRssSources();
        }
        
        // adds a new theme category.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void addThemeCategory(DTThemeCategoryMovAdmin dtThemeCategory)
        {
            ControllersHub.Instance.getIMovAdminController().addThemeCategory(DTToClass.DTToThemeCategory(dtThemeCategory));
        }
        
        // removes a current theme category.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public bool removeThemeCategory(DTThemeCategoryMovAdmin dtThemeCategory)
        {
            return ControllersHub.Instance.getIMovAdminController().removeThemeCategory(DTToClass.DTToThemeCategory(dtThemeCategory));
        }

        // gets the theme categories.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTThemeCategoriesColMovAdmin listThemeCategories()
        {
            // create new theme categories datatype collection
            DTThemeCategoriesColMovAdmin dtThemeCategoriesCol = new DTThemeCategoriesColMovAdmin();
            dtThemeCategoriesCol.items = new Collection<DTThemeCategoryMovAdmin>();

            // get theme categories from the controller
            Collection<CategoriasTematica> themeCategoriesCol = ControllersHub.Instance.getIMovAdminController().listThemeCategories();

            // add theme categories to the datatype collection
            foreach (CategoriasTematica themeCategory in themeCategoriesCol)
            {
                dtThemeCategoriesCol.items.Add(ClassToDT.ThemeCategoryToDTMovAdmin(themeCategory));
            }

            // return the collection
            return dtThemeCategoriesCol;
        }

        // returns all the data of the user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTUserDetails_MovAdmin getUserDetails(DTUser_MovAdmin dtUser)
        {
            // get user object
            Usuario user = DTToClass.DTToUser(dtUser);

            // create user details
            DTUserDetails_MovAdmin userDetails = new DTUserDetails_MovAdmin();
            userDetails.user = ClassToDT.UserToDT_MovAdmin(ControllersHub.Instance.getIMovAdminController().getUser(user));
            userDetails.resources = new Collection<DTResource_MovAdmin>();

            // get resources.
            Collection<Recurso> resourcesCol = ControllersHub.Instance.getIMovAdminController().getResourcesListUser(user);
            foreach (Recurso resource in resourcesCol)
            {
                userDetails.resources.Add(ClassToDT.ResourceToDT_MovAdmin(resource));
            }

            // return the datatype.
            return userDetails;
        }

        // returns all users.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTUsersCol_MovAdmin getUsersListFull()
        {
            // create new theme categories datatype collection
            DTUsersCol_MovAdmin dtUsersCol = new DTUsersCol_MovAdmin();
            dtUsersCol.items = new Collection<DTUser_MovAdmin>();

            // get users from the controller
            Collection<Usuario> themeCategoriesCol = ControllersHub.Instance.getIMovAdminController().getUsersListFull();

            // add users to the datatype collection
            foreach (Usuario themeCategory in themeCategoriesCol)
            {
                dtUsersCol.items.Add(ClassToDT.UserToDT_MovAdmin(themeCategory));
            }

            // return the collection
            return dtUsersCol;
        }

        // returns all users allowed.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTUsersCol_MovAdmin getUsersListAllowed()
        {
            // create new theme categories datatype collection
            DTUsersCol_MovAdmin dtUsersCol = new DTUsersCol_MovAdmin();
            dtUsersCol.items = new Collection<DTUser_MovAdmin>();

            // get users from the controller
            Collection<Usuario> themeCategoriesCol = ControllersHub.Instance.getIMovAdminController().getUsersListAllowed();

            // add users to the datatype collection
            foreach (Usuario themeCategory in themeCategoriesCol)
            {
                dtUsersCol.items.Add(ClassToDT.UserToDT_MovAdmin(themeCategory));
            }

            // return the collection
            return dtUsersCol;
        }

        // returns all users banned.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTUsersCol_MovAdmin getUsersListBanned()
        {
            // create new theme categories datatype collection
            DTUsersCol_MovAdmin dtUsersCol = new DTUsersCol_MovAdmin();
            dtUsersCol.items = new Collection<DTUser_MovAdmin>();

            // get users from the controller
            Collection<Usuario> themeCategoriesCol = ControllersHub.Instance.getIMovAdminController().getUsersListBanned();

            // add users to the datatype collection
            foreach (Usuario themeCategory in themeCategoriesCol)
            {
                dtUsersCol.items.Add(ClassToDT.UserToDT_MovAdmin(themeCategory));
            }

            // return the collection
            return dtUsersCol;
        }

        // bans a user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void banUser(DTUser_MovAdmin user)
        {
            ControllersHub.Instance.getIMovAdminController().banUser(DTToClass.DTToUser (user));
        }

        // reallows a user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void reallowUser(DTUser_MovAdmin user)
        {
            ControllersHub.Instance.getIMovAdminController().reallowUser(DTToClass.DTToUser(user));
        }

        // returns all resources.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTResourcesCol_MovAdmin getResourcesListAll()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getIMovAdminController().getResourcesListAll();

            // create new resources datatypes collection.
            DTResourcesCol_MovAdmin dtResourcesCol = new DTResourcesCol_MovAdmin();
            dtResourcesCol.items = new Collection<DTResource_MovAdmin>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT_MovAdmin(resource));
            }

            // return the collection.
            return dtResourcesCol;
        }

        // returns all resources enabled.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTResourcesCol_MovAdmin getResourcesListEnabled()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getIMovAdminController().getResourcesListEnabled();

            // create new resources datatypes collection.
            DTResourcesCol_MovAdmin dtResourcesCol = new DTResourcesCol_MovAdmin();
            dtResourcesCol.items = new Collection<DTResource_MovAdmin>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT_MovAdmin(resource));
            }

            // return the collection.
            return dtResourcesCol;
        }

        // returns all resources disabled.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTResourcesCol_MovAdmin getResourcesListDisabled()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getIMovAdminController().getResourcesListDisabled();

            // create new resources datatypes collection.
            DTResourcesCol_MovAdmin dtResourcesCol = new DTResourcesCol_MovAdmin();
            dtResourcesCol.items = new Collection<DTResource_MovAdmin>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT_MovAdmin(resource));
            }

            // return the collection.
            return dtResourcesCol;
        }

        // bans a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void disableResource(DTResource_MovAdmin resource)
        {
            ControllersHub.Instance.getIMovAdminController().disableResource(DTToClass.DTToResource(resource));
        }

        // reallows a resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void enableResource(DTResource_MovAdmin resource)
        {
            ControllersHub.Instance.getIMovAdminController().enableResource(DTToClass.DTToResource(resource));
        }

        // returns a users register report.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public DTUsersRegisterReport getUsersRegisterReport(DTUsersRegisterReport dtUsersReport)
        {
            return ControllersHub.Instance.getIMovAdminController().getUsersRegisterReport(dtUsersReport);
        }
    }
}
