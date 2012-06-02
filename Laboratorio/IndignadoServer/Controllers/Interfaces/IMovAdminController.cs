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

        // returns a list of available layouts
        List<DTLayout> getLayouts();

        // adds a new rss resource.
        void addRssSource(RssFeed rssSource);

        // removes a current rss resource.
        void removeRssSource(RssFeed rssSource);

        // gets the rss resources.
        DTRssSourcesCol listRssSources();

        // adds a new theme category.
        void addThemeCategory(CategoriasTematica themeCategory);

        // removes a current theme category.
        void removeThemeCategory(CategoriasTematica themeCategory);

        // gets the theme categories.
        Collection<CategoriasTematica> listThemeCategories();
        
        // returns all the data of the user.
        Usuario getUser(Usuario user);
        
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

        // returns all resources.
        Collection<Recurso> getResourcesListAll();

        // returns all resources enabled.
        Collection<Recurso> getResourcesListEnabled();

        // returns all resources disabled.
        Collection<Recurso> getResourcesListDisabled();

        // returns all resources published by the given user.
        Collection<Recurso> getResourcesListUser(Usuario user);

        // disable a resource.
        void disableResource(Recurso resource);

        // enable a resource.
        void enableResource(Recurso resource);

        // returns a users register report.
        DTUsersRegisterReport getUsersRegisterReport(DTUsersRegisterReport dtUsersReport);
    }
}
