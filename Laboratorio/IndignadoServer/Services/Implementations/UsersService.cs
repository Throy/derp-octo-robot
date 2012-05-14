using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Controllers;

namespace IndignadoServer.Services
{
    public class UsersService : IUsersService
    {
        // returns all theme categories.
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
                dtThemeCategoriesCol.items.Add(ClassToDT.ThemeCategoryUsersToDT(themeCategory));
            }

            // return the collection
            return dtThemeCategoriesCol;
        }
    }
}
