﻿using System.Collections.Generic;
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
            // get rss items datatypes.
            Collection<RssItem> rssItemsCol = ControllersHub.Instance.getINewsResourcesController().getNewsList();

            // create new rss items datatypes collection.
            DTRssItemsCol dtRssItemsCol = new DTRssItemsCol();
            dtRssItemsCol.items = new Collection<DTRssItem>();

            // add rss items to the datatypes collection.
            foreach (RssItem rssItem in rssItemsCol)
            {
                dtRssItemsCol.items.Add(ClassToDT.RssItemToDT(rssItem));
            }

            // return the collection.
            return dtRssItemsCol;
        }

        // returns all resources.
        public DTResourcesCol getResourcesList()
        {
            // get resources datatypes.
            Collection<Recurso> recursosCol = ControllersHub.Instance.getINewsResourcesController().getResourcesList();

            // create new resources datatypes collection.
            DTResourcesCol dtResourcesCol = new DTResourcesCol();
            dtResourcesCol.items = new Collection<DTResource>();

            // add meetings to the datatypes collection.
            foreach (Recurso resource in recursosCol)
            {
                dtResourcesCol.items.Add(ClassToDT.ResourceToDT(resource));
            }

            // add a sample resource
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

            // return the collection.
            return dtResourcesCol;
        }
    }
}
