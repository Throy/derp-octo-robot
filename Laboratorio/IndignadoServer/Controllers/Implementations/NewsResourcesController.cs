using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.RegularExpressions;
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
            /*
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<RssFeed> fuentesEnum = indignadoContext.ExecuteQuery<RssFeed>("SELECT idMovimiento, url, tag FROM RssFeeds WHERE idMovimiento = {0}", IdMovement);
            
            foreach (RssFeed source in fuentesEnum)
            {
                List<RssItem> rssItemsList = RssDocument.Load(new System.Uri(source.url)).Channel.Items;
            }
            */

            // get feeds from the source.
            List<RssItem> rssItemsList1 = RssDocument.Load(new System.Uri("http://180.com.uy/feed.php")).Channel.Items;
            List<RssItem> rssItemsList2 = RssDocument.Load(new System.Uri("http://www.montevideo.com.uy/anxml.aspx?59")).Channel.Items;
            List<RssItem> rssItemsList3 = RssDocument.Load(new System.Uri("http://www.elobservador.com.uy/rss/nacional/")).Channel.Items;
            List<RssItem> rssItemsList4 = RssDocument.Load(new System.Uri("http://cnnespanol.cnn.com/feed/")).Channel.Items;
            
            // create new rss items collection.
            Collection<RssItem> rssItemsCol = new Collection<RssItem>();
            for (int idx = 0; idx < 4; idx += 1)
            {
                rssItemsCol.Add(rssItemsList1[idx]);
                rssItemsCol.Add(rssItemsList2[idx]);
                rssItemsCol.Add(rssItemsList3[idx]);
                rssItemsCol.Add(rssItemsList4[idx]);
            }

            return rssItemsCol;
        }

        // returns all resources.
        public Collection<Recurso> getResourcesList()
        {
            // only get meetings from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> recursosEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, titulo, descripcion, fecha, tipo, urlLink, urlImage, urlVideo, urlThumb FROM Recursos LEFT JOIN Usuarios ON (Usuarios.id = Recursos.idUsuario) WHERE (Usuarios.idMovimiento = {0})", IdMovement);

            // create new resources collection.
            Collection<Recurso> recursosCol = new Collection<Recurso>();
            foreach (Recurso resource in recursosEnum)
            {
                // get number of likes
                IEnumerable<int> numbersLikes = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Aprobaciones WHERE idRecurso = {0}", resource.id);
                foreach (int numberLikes in numbersLikes)
                {
                    resource.cantAprobaciones = numberLikes;
                }

                // get own like
                if (UserInfo != null)
                {
                    IEnumerable<int> iLikesIt = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Aprobaciones WHERE (idRecurso = {0}) AND (idUsuario = {1})", resource.id, UserInfo.Id);
                    foreach (int iLikeIt in iLikesIt)
                    {
                        resource.meGusta = iLikeIt;
                    }
                }

                // add item to the collection
                recursosCol.Add(resource);
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
    }
}
