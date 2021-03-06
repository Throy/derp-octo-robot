﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface IUsersController
    {
        // gets the admin's movement.
        Movimiento getMovement();

        // returns all theme categories.
        Collection<CategoriasTematica> getThemeCategoriesList();

        // get interested in a theme category.
        void getInterestedThemeCategory(CategoriasTematica themeCategory);

        // get uninterested in a theme category.
        void getUninterestedThemeCategory(CategoriasTematica themeCategory);

        // returns the data of the user.
        Usuario getUser();
        
        // updates the data of the user.
        void setUser(Usuario user);
    }
}
