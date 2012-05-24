using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface IMovAdminController
    {
        // gets the admin's movement.
        Movimiento getMovement();

        // changes the configuration of the movement.
        void setMovement(Movimiento dtMovement);

        // adds a new rss resource.
        void addRssSource(String url, String tag);

        // removes a current rss resource.
        void removeRssSource(String url, String tag);

        // gets the rss resources.
        DTRssSourcesCol listRssSources();

        // adds a new theme category.
        void addThemeCategory(CategoriasTematica themeCategory);

        // removes a current theme category.
        void removeThemeCategory(CategoriasTematica themeCategory);

        // gets the theme categories.
        Collection<CategoriasTematica> listThemeCategories();
        
        // returns all users.
        Collection<Usuario> getUsersListFull();
        
        // returns all users allowed.
        Collection<Usuario> getUsersListAllowed();

        // returns all users banned.
        Collection<Usuario> getUsersListBanned();

        // bans a user.
        void banUser(Usuario user);

        // reallows a user.
        void reallowUser(Usuario user);
    }
}
