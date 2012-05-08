using System.Collections.Generic;
using System.Collections.ObjectModel;
using RssToolkit.Rss;

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
             
             * rssItemsCol = NewsResourcesController.getResourcesList()
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
    }
}
