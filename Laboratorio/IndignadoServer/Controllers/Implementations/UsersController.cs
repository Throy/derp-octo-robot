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
                themeCategory.miInteres = -1;
                /*
                if (UserInfo != null)
                {
                    IEnumerable<int> myInterests = indignadoContext.ExecuteQuery<int>("SELECT interes FROM Interes WHERE (idCategoriaTematica = {0}) AND (idUsuario = {1})", themeCategory.id, UserInfo.Id);
                    foreach (int myInterest in myInterests)
                    {
                        themeCategory.miInteres = myInterest;
                    }
                }
                 * */

                // add item to the collection
                themeCategoriesCol.Add(themeCategory);
            }

            // return the collection
            return themeCategoriesCol;
        }
    }
}
