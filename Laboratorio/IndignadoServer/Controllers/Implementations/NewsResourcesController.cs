using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.ServiceModel;
using IndignadoServer.LinqDataContext;
using RssToolkit.Rss;

namespace IndignadoServer.Controllers
{
    class NewsResourcesController : IndignadoController, INewsResourcesController
    {
        // ******************
        // controller methods
        // ******************
        
        // returns all rss items.
        public Collection<RssItem> getNewsList()
        {
            // Java, esto es para vos.
            
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<RssFeed> fuentesEnum = indignadoContext.ExecuteQuery<RssFeed>("SELECT idMovimiento, url, tag FROM RssFeeds WHERE idMovimiento = {0}", IdMovement);

            Collection<RssItem> rssItemsCol = new Collection<RssItem>();
            Collection<List<RssItem>> ColRssLists = new Collection<List<RssItem>>();
            foreach (RssFeed source in fuentesEnum)
            {
                List<RssItem> rssItemsList = RssDocument.Load(new System.Uri(source.url)).Channel.Items;
                ColRssLists.Add(rssItemsList);
                if (ColRssLists.Count > 10)
                {
                    break;
                }
            }

            for (int j = 0; j < 10 ; j++)
            {
                List<RssItem> rssItemsList = ColRssLists[j % ColRssLists.Count];
                if (rssItemsList.Count > (j / ColRssLists.Count))
                {
                    rssItemsCol.Add(rssItemsList[j / ColRssLists.Count]);
                }
            }
            return rssItemsCol;
        }

        // returns all resources.
        public Collection<Recurso> getResourcesList()
        {
            // get all resources from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> recursosEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, Usuarios.apodo AS apodoUsuario, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb, CantAprobaciones.cantAprobaciones FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) LEFT JOIN (SELECT idRecurso, COUNT (idUsuario) AS cantAprobaciones FROM Aprobaciones GROUP BY idRecurso) CantAprobaciones ON (CantAprobaciones.idRecurso = Recursos.id) WHERE (Usuarios.idMovimiento = {0}) AND (Recursos.deshabilitado = {1}) ORDER BY Recursos.id DESC", IdMovement, 0);
            Movimiento movement = indignadoContext.Movimientos.Single(x => x.id == IdMovement);
            return toResourcesCol(recursosEnum, movement.maxUltimosRecursosM);
        }

        // returns the top ranked resources.
        public Collection<Recurso> getResourcesListTopRanked()
        {
            // get top ranked resources from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> recursosEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, Usuarios.apodo AS apodoUsuario, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb, CantAprobaciones.cantAprobaciones FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) LEFT JOIN (SELECT idRecurso, COUNT (idUsuario) AS cantAprobaciones FROM Aprobaciones GROUP BY idRecurso) CantAprobaciones ON (CantAprobaciones.idRecurso = Recursos.id) WHERE (Usuarios.idMovimiento = {0}) AND (Recursos.deshabilitado = {1}) ORDER BY CantAprobaciones.cantAprobaciones DESC, Recursos.id DESC", IdMovement, 0);
            Movimiento movement = indignadoContext.Movimientos.Single(x => x.id == IdMovement);
            return toResourcesCol(recursosEnum, movement.maxRecursosPopularesN);
        }

        // converts a resources enumerable to a collection.
        private Collection<Recurso> toResourcesCol(IEnumerable<Recurso> recursosEnum, int numberItems)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // create new resources collection.
            Collection<Recurso> recursosCol = new Collection<Recurso>();

            // for each resource, ...
            foreach (Recurso resource in recursosEnum)
            {
                // get own like
                if (UserInfo != null)
                {
                    IEnumerable<int> iLikesIt = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Aprobaciones WHERE (idRecurso = {0}) AND (idUsuario = {1})", resource.id, UserInfo.Id);
                    foreach (int iLikeIt in iLikesIt)
                    {
                        resource.meGusta = iLikeIt;
                    }
                }

                // get own mark as inappropriate
                if (UserInfo != null)
                {
                    IEnumerable<int> myMarksInappr = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM MarcasInadecuados WHERE (idRecurso = {0}) AND (idUsuario = {1})", resource.id, UserInfo.Id);
                    foreach (int myMarkInappr in myMarksInappr)
                    {
                        resource.yoMarqueInadecuado = myMarkInappr;
                    }
                }

                // add item to the collection
                recursosCol.Add(resource);

                // stop at the desired number of items.
                if (recursosCol.Count >= numberItems)
                {
                    break;
                }
            }

            return recursosCol;
        }

        // creates a resource.
        public void createResource(Recurso resource)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // set internal and foreign ids
            resource.idUsuario = UserInfo.Id;
            resource.fecha = DateTime.UtcNow;
            resource.deshabilitado = 0;

            indignadoContext.Recursos.InsertOnSubmit(resource);
            indignadoContext.SubmitChanges();
        }

        /// gets resource data from the link.
        public Recurso getResourceData(string link)
        {
            // create resource
            Recurso resource = new Recurso();
            
            // get website
            string website = new WebClient().DownloadString(link);

            // get data
            if (website != null)
            {
                // get title
                resource.titulo = Regex.Match(website, @"<title>(.+?)</title>").Value;
                resource.titulo = (resource.titulo == null) || (resource.titulo.Length < 7) ? null : resource.titulo.Substring(7);
                resource.titulo = (resource.titulo == null) || (resource.titulo.Length < 7) ? null : resource.titulo.Substring(0, resource.titulo.Length - 8);

                // get description
                resource.descripcion = Regex.Match(website, @"<meta(.+?)name\=\""(description|Description)\""(.+?)(/\s*|></\s*meta>)>").Value;
                resource.descripcion = (resource.descripcion == null) ? null : Regex.Match(resource.descripcion, @"content\=\"".*?\""").Value;
                resource.descripcion = (resource.descripcion == null) || (resource.descripcion.Length < 9) ? null : resource.descripcion.Substring(9);
                resource.descripcion = (resource.descripcion == null) || (resource.descripcion.Length < 5) ? null : resource.descripcion.Substring(0, resource.descripcion.Length - 1);
                
                // get images
                //resource.logo;
            }

            return resource;
        }

        // likes a resource.
        public void likeResource(Recurso resource)
        {
            // create a likeResource
            Aprobacione likeResource = new Aprobacione();
            likeResource.idRecurso = resource.id;
            likeResource.idUsuario = UserInfo.Id;

            // add likeResource to the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.Aprobaciones.InsertOnSubmit(likeResource);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }

        // unlikes a resource.
        public void unlikeResource(Recurso resource)
        {
            // remove likeResource from the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Aprobaciones WHERE (idRecurso = {0}) AND (idUsuario = {1})", resource.id, UserInfo.Id);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }
        

        // mark a resource as inappropriate.
        public void markResourceInappropriate(Recurso resource)
        {
            // create a markInappropriate
            MarcasInadecuado markInappropriate = new MarcasInadecuado();
            markInappropriate.idRecurso = resource.id;
            markInappropriate.idUsuario = UserInfo.Id;

            try
            {
                // get database context.
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

                // get the movement.
                Movimiento movement = indignadoContext.Movimientos.Single(x => x.id == IdMovement);

                // add markInappropriate to the database.
                indignadoContext.MarcasInadecuados.InsertOnSubmit(markInappropriate);
                indignadoContext.SubmitChanges();
                indignadoContext = new IndignadoDBDataContext();

                // get number of marks of the resource.
                int numberMarksResource = 0;
                IEnumerable<int> numbersMarksR = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM MarcasInadecuados WHERE (idRecurso = {0})", resource.id);
                foreach (int numberMarksR in numbersMarksR)
                {
                    numberMarksResource = numberMarksR;
                }

                // if number of marks matches X, disable the resource.
                if (numberMarksResource >= movement.maxMarcasInadecuadasRecursoX)
                {
                    indignadoContext.ExecuteQuery<int>("UPDATE Recursos SET deshabilitado = {0} WHERE id = {1}", 1, resource.id);
                }

                // get this resources's user id.
                int thisUserId = -1;
                IEnumerable<int> thisUsersID = indignadoContext.ExecuteQuery<int>("SELECT idUsuario FROM Recursos WHERE (id = {0})", resource.id);
                foreach (int thisUserID in thisUsersID)
                {
                    thisUserId = thisUserID;
                }

                // get number of disabled resources published by this resources's user.
                int numberMarksUser = 0;
                IEnumerable<int> numbersMarksU = indignadoContext.ExecuteQuery<int>
                    ("SELECT COUNT(*) FROM Recursos WHERE (idUsuario = {0}) AND (deshabilitado = {1})", thisUserId, 1);
                foreach (int numberMarksU in numbersMarksU)
                {
                    numberMarksUser = numberMarksU;
                }

                // if number of marks matches Z, ban the user.
                if (numberMarksUser >= movement.maxRecursosInadecuadosUsuarioZ)
                {
                    indignadoContext.ExecuteQuery<int>("UPDATE Usuarios SET banned = {0} WHERE id = {1}", true, thisUserId);
                }

                // commit changes to the database.
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }
        
        // unmark a resource as inappropriate.
        public void unmarkResourceInappropriate(Recurso resource)
        {
            // remove markInappropriate from the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM MarcasInadecuados WHERE (idRecurso = {0}) AND (idUsuario = {1})", resource.id, UserInfo.Id);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }
    }
}
