using System.Linq;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace IndignadoServer.Controllers
{
    class MovAdminController : IndignadoController, IMovAdminController
    {
        // ******************
        // controller methods
        // ******************

        // gets the admin's movement.
        public Movimiento getMovement()
        {
            // get movement from database
            Movimiento movement;
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            try
            {
                movement = indignadoContext.Movimientos.Single(x => x.id == IdMovement);
            }
            catch
            {
                movement = null;
            }
            return movement;
        }

        // changes the configuration of the movement.
        public void setMovement(Movimiento movement)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            indignadoContext.ExecuteCommand("UPDATE Movimiento SET nombre = {0}, descripcion = {1}, latitud = {2}, longitud = {3} WHERE id = {4}", movement.nombre, movement.descripcion, movement.latitud, movement.longitud, IdMovement);
        }

        // adds a new rss resource.
        public void addRssSource(String url, String tag){
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            RssFeed rssFeed = new RssFeed();
            rssFeed.url = url;
            rssFeed.tag = tag;
            rssFeed.idMovimiento = IdMovement;
     
            indignadoContext.RssFeeds.InsertOnSubmit(rssFeed);
            indignadoContext.SubmitChanges();
        }

        // removes a current rss resource.
        public void removeRssSource(String url, String tag)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            try {
                if (tag == null)
                {
                    indignadoContext.ExecuteCommand("DELETE FROM RssFeeds WHERE url = {0} AND idMovimiento = {1} ", url, IdMovement);
                }
                else
                {
                    indignadoContext.ExecuteCommand("DELETE FROM RssFeeds WHERE url = {0} AND tag = {1} AND idMovimiento = {2}  ", url, tag, IdMovement);
                }
            
            }
            catch{
            }
        }

        // gets the rss resources.
        public DTRssSourcesCol listRssSources()
        {
            DTRssSourcesCol result = new DTRssSourcesCol();
            result.items = new Collection<DTRssSource>();
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<RssFeed> ressEnum = indignadoContext.ExecuteQuery<RssFeed>("SELECT url,idMovimiento,tag FROM RssFeeds WHERE idMovimiento = {0}", IdMovement);
            foreach (RssFeed rss in ressEnum)
            {
                DTRssSource dtRss = new DTRssSource();
                dtRss.tag = rss.tag;
                dtRss.url = rss.url;
                result.items.Add(dtRss);
            }
            return result;
        }

        
        // adds a new theme category.
        public void addThemeCategory(CategoriasTematica themeCategory)
        {
            // set foreign ids 
            themeCategory.idMovimiento = IdMovement;

            // add the theme category to the database
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.CategoriasTematicas.InsertOnSubmit(themeCategory);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }
        
        // removes a current theme category.
        public void removeThemeCategory(CategoriasTematica themeCategory)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            indignadoContext.ExecuteCommand("DELETE FROM CategoriasTematicas WHERE (id = {0})", themeCategory.id);
        }
        
        // gets the theme categories.
        public Collection<CategoriasTematica> listThemeCategories()
        {
            // only get theme categories from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<CategoriasTematica> themeCategoriesEnum = indignadoContext.ExecuteQuery<CategoriasTematica>("SELECT id, idMovimiento, titulo, descripcion FROM CategoriasTematicas WHERE idMovimiento = {0}", IdMovement);

            Collection<CategoriasTematica> themeCategoriesCol = new Collection<CategoriasTematica>();
            foreach (CategoriasTematica themeCategory in themeCategoriesEnum)
            {
                /*
                // get own attendance
                themeCategory.miInteres = -1;
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

        // returns all the data of the user.
        public Usuario getUser(Usuario user)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            Usuario userFull = indignadoContext.Usuarios.SingleOrDefault(u => (u.id == user.id));

            // get number of resources marked as inappropriate.
            IEnumerable<int> numbersMarksInappropriateResources = indignadoContext.ExecuteQuery<int>
                ("SELECT COUNT(*) FROM (SELECT idRecurso FROM MarcasInadecuados GROUP BY idRecurso) RecursosMarcadosInadecuado LEFT JOIN Recursos ON Recursos.id = RecursosMarcadosInadecuado.idRecurso WHERE Recursos.idUsuario = {0}", userFull.id);
            foreach (int numberMarksInappropriateResources in numbersMarksInappropriateResources)
            {
                userFull.cantRecursosMarcadosInadecuados = numberMarksInappropriateResources;
            }

            // get number of disabled resources.
            IEnumerable<int> numbersDisabledResources = indignadoContext.ExecuteQuery<int>
                ("SELECT COUNT(*) FROM Recursos WHERE (idUsuario = {0}) AND (deshabilitado = {1})", userFull.id, 1);
            foreach (int numberDisabledResources in numbersDisabledResources)
            {
                userFull.cantRecursosDeshabilitados = numberDisabledResources;
            }

            return userFull;
        }

        // returns all users.
        public Collection<Usuario> getUsersListFull()
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Usuario> usersEnum = indignadoContext.ExecuteQuery<Usuario>
                ("SELECT * FROM Usuarios WHERE (idMovimiento = {0}) AND (privilegio = {1})", IdMovement, 0);
            return toUsersCol(usersEnum);
        }

        // returns all users allowed.
        public Collection<Usuario> getUsersListAllowed()
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Usuario> usersEnum = indignadoContext.ExecuteQuery<Usuario>
                ("SELECT * FROM Usuarios WHERE (idMovimiento = {0}) AND (privilegio = {1}) AND (banned = {2})", IdMovement, 0, false);
            return toUsersCol(usersEnum);
        }

        // returns all users banned.
        public Collection<Usuario> getUsersListBanned()
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Usuario> usersEnum = indignadoContext.ExecuteQuery<Usuario>
                ("SELECT * FROM Usuarios WHERE (idMovimiento = {0}) AND (privilegio = {1}) AND (banned = {2})", IdMovement, 0, true);
            return toUsersCol(usersEnum);
        }

        // convert users enumerable to collection.
        private Collection<Usuario> toUsersCol(IEnumerable<Usuario> usersEnum)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // create new users collection.
            Collection<Usuario> usersCol = new Collection<Usuario>();

            // for each user in the enumerable, ...
            foreach (Usuario user in usersEnum)
            {
                // get number of resources marked as inappropriate.
                IEnumerable<int> numbersMarksInappropriateResources = indignadoContext.ExecuteQuery<int>
                    ("SELECT COUNT(*) FROM (SELECT idRecurso FROM MarcasInadecuados GROUP BY idRecurso) RecursosMarcadosInadecuado LEFT JOIN Recursos ON Recursos.id = RecursosMarcadosInadecuado.idRecurso WHERE Recursos.idUsuario = {0}", user.id);
                foreach (int numberMarksInappropriateResources in numbersMarksInappropriateResources)
                {
                    user.cantRecursosMarcadosInadecuados = numberMarksInappropriateResources;
                }

                // get number of disabled resources.
                IEnumerable<int> numbersDisabledResources = indignadoContext.ExecuteQuery<int>
                    ("SELECT COUNT(*) FROM Recursos WHERE (idUsuario = {0}) AND (deshabilitado = {1})", user.id, 1);
                foreach (int numberDisabledResources in numbersDisabledResources)
                {
                    user.cantRecursosDeshabilitados = numberDisabledResources;
                }

                // add user to the collection.
                usersCol.Add(user);
            }

            // return the users collection.
            return usersCol;
        }

        // bans a user.
        public void banUser(Usuario user)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            indignadoContext.ExecuteCommand("UPDATE Usuarios SET banned = {0} WHERE id = {1}", 1, user.id);
        }

        // reallows a user.
        public void reallowUser(Usuario user)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            indignadoContext.ExecuteCommand("UPDATE Usuarios SET banned = {0} WHERE id = {1}", 0, user.id);
        }

        // returns all resources.
        public Collection<Recurso> getResourcesListAll()
        {
            // get all resources from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> resourcesEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, Usuario.apodo, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb, deshabilitado FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) WHERE Usuarios.idMovimiento = {0}", IdMovement);
            return toResourcesCol(resourcesEnum);
        }

        // returns all resources enabled.
        public Collection<Recurso> getResourcesListEnabled()
        {
            // get all resources from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> resourcesEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, Usuarios.apodo AS apodoUsuario, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb, deshabilitado FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) WHERE (Usuarios.idMovimiento = {0}) AND (Recursos.deshabilitado = {1})", IdMovement, 0);
            return toResourcesCol(resourcesEnum);
        }

        // returns all resources disabled.
        public Collection<Recurso> getResourcesListDisabled()
        {
            // get all resources from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> resourcesEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, Usuarios.apodo AS apodoUsuario, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb, deshabilitado FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) WHERE (Usuarios.idMovimiento = {0}) AND (Recursos.deshabilitado = {1})", IdMovement, 1);
            return toResourcesCol(resourcesEnum);
        }

        // returns all resources published by the given user.
        public Collection<Recurso> getResourcesListUser(Usuario user)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> resourcesEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, Usuarios.apodo AS apodoUsuario, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb, deshabilitado FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) WHERE Usuarios.id = {0}", user.id);
            return toResourcesCol(resourcesEnum);
        }

        // convert users enumerable to collection.
        private Collection<Recurso> toResourcesCol(IEnumerable<Recurso> resourcesEnum)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // create new resources collection.
            Collection<Recurso> recursosCol = new Collection<Recurso>();

            // for each resource in the enumerable, ...
            foreach (Recurso resource in resourcesEnum)
            {
                // get number of likes
                IEnumerable<int> numbersLikes = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Aprobaciones WHERE idRecurso = {0}", resource.id);
                foreach (int numberLikes in numbersLikes)
                {
                    resource.cantAprobaciones = numberLikes;
                }

                // get number of marks as inappropriate
                IEnumerable<int> numbersMarksInappropriate = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM MarcasInadecuados WHERE idRecurso = {0}", resource.id);
                foreach (int numberMarksInappropriate in numbersMarksInappropriate)
                {
                    resource.cantMarcasInadecuado = numberMarksInappropriate;
                }
                
                // add item to the collection
                recursosCol.Add(resource);
            }

            return recursosCol;
        }

        // bans a resource.
        public void disableResource(Recurso resource)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            indignadoContext.ExecuteCommand("UPDATE Recursos SET deshabilitado = {0} WHERE id = {1}", 1, resource.id);
        }

        // reallows a resource.
        public void enableResource(Recurso resource)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            indignadoContext.ExecuteCommand("UPDATE Recursos SET deshabilitado = {0} WHERE id = {1}", 0, resource.id);
        }
    }
}
