using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
            IEnumerable<Fuente> fuentesEnum = indignadoContext.ExecuteQuery<Fuente>("SELECT id, link FROM Fuentes WHERE idMovimiento = {0}", IdMovement);
            
            foreach (Fuente source in fuentesEnum)
            {
             * List<RssItem> rssItemsList = RssDocument.Load(new System.Uri(source.link)).Channel.Items;
            }
            */

            // get feeds from the source.
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

            return rssItemsCol;
        }

        // returns all resources.
        public Collection<Recurso> getResourcesList()
        {
            // only get meetings from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Recurso> recursosEnum = indignadoContext.ExecuteQuery<Recurso>
                ("SELECT Recursos.id, Recursos.idUsuario, titulo, descripcion, logo, fecha, tipo, link FROM Recursos LEFT JOIN Usuarios ON ((Usuarios.id = Recursos.idUsuario) AND (Usuarios.idMovimiento = {0}))", 9);

 //           select * from a LEFT OUTER JOIN b on a.a = b.b;


            // create new resources collection.
            Collection<Recurso> recursosCol = new Collection<Recurso>();
            foreach (Recurso meeting in recursosEnum)
            {
                recursosCol.Add(meeting);
            }

            return recursosCol;
        }
    }
}
