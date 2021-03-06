﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Controllers;

namespace IndignadoServer.Services
{
    public class UsersService : IUsersService
    {
        // gets the user's movement.
        public DTMovement getMovement()
        {
            try
            {
                return ClassToDT.MovementToDT(ControllersHub.Instance.getIUsersController().getMovement());
            }
            catch
            {
                return null;
            }
        }

        // returns all theme categories.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public DTThemeCategoriesColUsers getThemeCategoriesList()
        {
            // create new theme categories datatype collection
            DTThemeCategoriesColUsers dtThemeCategoriesCol = new DTThemeCategoriesColUsers();
            dtThemeCategoriesCol.items = new Collection<DTThemeCategoryUsers>();

            // get theme categories from the controller
            Collection<CategoriasTematica> themeCategoriesCol = ControllersHub.Instance.getIUsersController().getThemeCategoriesList();

            // add theme categories to the datatype collection
            foreach (CategoriasTematica themeCategory in themeCategoriesCol)
            {
                dtThemeCategoriesCol.items.Add(ClassToDT.ThemeCategoryToDTUsers(themeCategory));
            }

            // return the collection
            return dtThemeCategoriesCol;
        }
        
        // get interested in a theme category.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void getInterestedThemeCategory(DTThemeCategoryUsers dtThemeCategory)
        {
            ControllersHub.Instance.getIUsersController().getInterestedThemeCategory(DTToClass.DTToThemeCategory(dtThemeCategory));
        }
        
        // get uninterested in a theme category.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void getUninterestedThemeCategory(DTThemeCategoryUsers dtThemeCategory)
        {
            ControllersHub.Instance.getIUsersController().getUninterestedThemeCategory(DTToClass.DTToThemeCategory(dtThemeCategory));
        }

        // returns the data of the user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public DTUser_Users getUser()
        {
            return ClassToDT.UserToDT_Users (ControllersHub.Instance.getIUsersController().getUser());
        }

        // updates the data of the user.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void setUser(DTUser_Users dtUser)
        {
            ControllersHub.Instance.getIUsersController().setUser(DTToClass.DTToUser(dtUser));
        }
    }
}
