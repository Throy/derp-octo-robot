using System.Collections.ObjectModel;
using System.Collections;
using RssToolkit.Rss;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResorceService" in both code and config file together.
    public class NewsResourcesService : INewsResourcesService
    {
        // returns all meetings
        public void getResourcesList()
        {
            // create new meetings datatype collection
            DTMeetingsCol dtMeetingsCol = new DTMeetingsCol();
            dtMeetingsCol.items = new Collection<DTMeeting>();

            RssDocument rss = RssDocument.Load(new System.Uri("http://es.autoblog.com/category/competicipn/rss.xml"));
        
            IEnumerable meetingsEnum = rss.SelectItems(10);

            IEnumerator iEnum = meetingsEnum.GetEnumerator();
            while (iEnum.MoveNext())
            {
                iEnum.GetType();
            }
        }
    }
}
