using System.Collections.Generic;
using System.Collections.ObjectModel;
using RssToolkit.Rss;
using IndignadoServer.Controllers;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResorceService" in both code and config file together.
    public class NewsResourcesService : INewsResourcesService
    {
        // returns all rss items.
        public DTRssItemsCol getNewsList()
        {
            /* esto va en el controlador */

            // get rss feed forom the source.
            List<RssItem> rssItemsList1 = RssDocument.Load(new System.Uri("http://180.com.uy/feed.php")).Channel.Items;
            List<RssItem> rssItemsList2 = RssDocument.Load(new System.Uri("http://www.montevideo.com.uy/anxml.aspx?59")).Channel.Items;
            List<RssItem> rssItemsList3 = RssDocument.Load(new System.Uri("http://www.elobservador.com.uy/rss/nacional/")).Channel.Items;
            List<RssItem> rssItemsList4 = RssDocument.Load(new System.Uri("http://cnnespanol.cnn.com/feed/")).Channel.Items;
        
            //List<RssItem> rssItemsList4 = RssDocument.Load(new System.Uri("http://es.autoblog.com/category/competicipn/rss.xml")).Channel.Items;
            

            // create new rss items collection.
            Collection<RssItem> rssItemsCol = new Collection<RssItem>();
            for (int idx = 0; idx < 4; idx += 1)
            {
                rssItemsCol.Add(rssItemsList1[idx]);
                rssItemsCol.Add(rssItemsList2[idx]);
                rssItemsCol.Add(rssItemsList3[idx]);
                rssItemsCol.Add(rssItemsList4[idx]);
            }

            /* esto sí va en el servicio 
             
             * rssItemsCol = NewsResourcesController.getNewsList()
             * 
             */

            DTRssItemsCol dtRssItemsCol = new DTRssItemsCol();
            dtRssItemsCol.items = new Collection<DTRssItem>();
            foreach (RssItem rssItem in rssItemsCol)
            {
                dtRssItemsCol.items.Add(ClassToDT.RssItemToDT(rssItem));
            }

            return dtRssItemsCol;
        }

        // returns all resources.
        public DTResourcesCol getResourcesList()
        {
            // only get meetings from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> recursosEnum = indignadoContext.ExecuteQuery<Recurso>("SELECT id, idUsuario, titulo, descripcion, logo, fecha, tipo, link FROM Recursos"); // *** FALTA AGREGAR WHERE idMovimiento = {0}", IdMovimiento);

            Collection<Recurso> recursosCol = new Collection<Recurso>();
            foreach (Recurso meeting in recursosEnum)
            {
                recursosCol.Add(meeting);
            }

            /* esto sí va en el servicio 
             
             * recursosCol = NewsResourcesController.getResourcesList()
             * 
             */

            DTResourcesCol dtResourcesCol = new DTResourcesCol();
            dtResourcesCol.items = new Collection<DTResource>();

            // add meetings to the datatype collection
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT(resource));
            }

            DTResource dtResource = new DTResource();
            dtResource.id = 0;
            dtResource.idUser = 1;
            dtResource.title = "Autito";
            dtResource.description = "el juego revolucionarazo";
            dtResource.link = "autito.tk";
            dtResource.thumbnail = "logo_autito.gif";
            dtResource.date = new System.DateTime (2012, 05, 24, 20, 38, 0);
            dtResource.numberLikes = 38;
            dtResourcesCol.items.Add(dtResource);

            return dtResourcesCol;
        }
    }
}
