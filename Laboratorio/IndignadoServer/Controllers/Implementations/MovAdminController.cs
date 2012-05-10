using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

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
            // *** lista de campos levantada de DTToClass.DTToMovement() ***

            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            movement.id = 0;
            indignadoContext.ExecuteCommand("UPDATE Movimiento SET nombre = {0}, descripcion = {1}, latitud = {2}, longitud = {3} WHERE id = {4}", movement.nombre, movement.descripcion, movement.latitud, movement.longitud, movement.id);
        }

        public void addRssSource(String url, String tag){
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            RssFeed rssFeed = new RssFeed();
            rssFeed.url = url;
            rssFeed.tag = tag;
            rssFeed.idMovimiento = IdMovement;
     
            indignadoContext.RssFeeds.InsertOnSubmit(rssFeed);
            indignadoContext.SubmitChanges();

        }

        public void removeRssSource(String url, String tag)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            try {
                if (tag == null)
                {
                    indignadoContext.ExecuteCommand("DELETE FROM RssFeeds WHERE url = {0} AND idMovimiento = {1} ", url, IdMovement);
                }
            }
            catch{
            }
        }

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

    }
}
