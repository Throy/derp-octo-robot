using System.Linq;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace IndignadoServer.Controllers
{
    class UsersController : IndignadoController, IUsersController
    {
        // ******************
        // controller methods
        // ******************

        // returns all theme categories.
        public Collection<CategoriasTematica> getThemeCategoriesList()
        {
            // only get theme categories from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<CategoriasTematica> themeCategoriesEnum = indignadoContext.ExecuteQuery<CategoriasTematica>("SELECT id, idMovimiento, titulo, descripcion FROM CategoriasTematicas WHERE idMovimiento = {0}", IdMovement);

            Collection<CategoriasTematica> themeCategoriesCol = new Collection<CategoriasTematica>();
            foreach (CategoriasTematica themeCategory in themeCategoriesEnum)
            {
                // get own interest
                if (UserInfo != null)
                {
                    IEnumerable<int> myInterests = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Intereses WHERE (idCategoriaTematica = {0}) AND (idUsuario = {1})", themeCategory.id, UserInfo.Id);
                    foreach (int myInterest in myInterests)
                    {
                        themeCategory.miInteres = myInterest;
                    }
                }

                // add item to the collection
                themeCategoriesCol.Add(themeCategory);
            }

            // return the collection
            return themeCategoriesCol;
        }


        // get interested in a theme category.
        public void getInterestedThemeCategory(CategoriasTematica themeCategory)
        {
            // create an interest
            Interese interest = new Interese();
            interest.idCategoriaTematica = themeCategory.id;
            interest.idUsuario = UserInfo.Id;

            // add interest to the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.Intereses.InsertOnSubmit(interest);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }

        // get uninterested in a theme category.
        public void getUninterestedThemeCategory(CategoriasTematica themeCategory)
        {
            // remove interest from the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Intereses WHERE (idCategoriaTematica = {0}) AND (idUsuario = {1})", themeCategory.id, UserInfo.Id);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }
    }
}
