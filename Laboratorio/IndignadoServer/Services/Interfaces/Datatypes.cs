using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;
using RssToolkit.Rss;
using System.Text.RegularExpressions;

namespace IndignadoServer.Services
{
    // *********
    // datatypes
    // *********

    // Meeting datatype
    [DataContract]
    public class DTMeeting
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int idMovement { get; set; }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String description { get; set; }

        [DataMember]
        public float locationLati { get; set; }

        [DataMember]
        public float locationLong { get; set; }

        [DataMember]
        public int minQuorum { get; set; }
    }

    // Meeting Collection datatype
    [DataContract]
    public class DTMeetingsCol
    {
        [DataMember]
        public Collection<DTMeeting> items { get; set; }
    }

    // Movement datatype
    [DataContract]
    public class DTMovement
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public int idLayout { get; set; }

        [DataMember]
        public String description { get; set; }

        [DataMember]
        public float locationLati { get; set; }

        [DataMember]
        public float locationLong { get; set; }
    }

    [DataContract]
    public class DTTenantInfo
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public bool habilitado { get; set; }

        [DataMember]
        public String logo { get; set; }

        [DataMember]
        public String layoutFile { get; set; }
    }

    // Movement Collection datatype
    [DataContract]
    public class DTMovementsCol
    {
        [DataMember]
        public Collection<DTMovement> items { get; set; }
    }

    // RssItems datatype
    [DataContract]
    public class DTRssItem
    {
        [DataMember]
        public String title { get; set; }

        [DataMember]
        public String description { get; set; }

        [DataMember]
        public String link { get; set; }

        [DataMember]
        public String image { get; set; }

        [DataMember]
        public DateTime date { get; set; }
    }

    // RssItems Collection datatype
    [DataContract]
    public class DTRssItemsCol
    {
        [DataMember]
        public Collection<DTRssItem> items { get; set; }
    }

    // **********
    // conversors
    // **********

    // converts classes to datatypes

    public class ClassToDT
    {
        public static Random random = new Random();

        public static DTMeeting MeetingToDT (Convocatoria meeting)
        {
            DTMeeting dtMeeting = new DTMeeting();
            dtMeeting.id = meeting.id;
            dtMeeting.idMovement = meeting.idMovimiento;
            dtMeeting.name = meeting.titulo;
            dtMeeting.description = meeting.descripcion;
            // *** ***
            dtMeeting.locationLati = meeting.latitud + (float) random.NextDouble();
            dtMeeting.locationLong = meeting.longitud + (float)random.NextDouble();
            dtMeeting.minQuorum = meeting.minQuorum == null? 0: meeting.minQuorum.Value;
            return dtMeeting;
        }

        public static DTMovement MovementToDT(Movimiento movement)
        {
            DTMovement dtMovement = new DTMovement();
            dtMovement.id = movement.id;
            dtMovement.name = movement.nombre;
            dtMovement.description = movement.descripcion;
            dtMovement.locationLati = movement.latitud;
            dtMovement.locationLong = movement.longitud;
            dtMovement.idLayout = movement.idLayout;
            return dtMovement;
        }

        public static DTRssItem RssItemToDT(RssItem rssItem)
        {
            DTRssItem dtRssItem = new DTRssItem();
            dtRssItem.title = rssItem.Title;
            dtRssItem.description = Regex.Replace(rssItem.Description, @"</?(a|img|div|p|strong) ?[^>]*?>", string.Empty);
            dtRssItem.link = (rssItem.Link == null) ? "" : rssItem.Link;
            dtRssItem.image = Regex.Match(rssItem.Description, @"<img[^>]*/>").Value;
            dtRssItem.image = (dtRssItem.image == null) ? null : Regex.Match(dtRssItem.image, @"src\=\"".*?\""").Value;
            dtRssItem.image = (dtRssItem.image == null) || (dtRssItem.image.Length < 5) ? null : dtRssItem.image.Substring(5);
            dtRssItem.image = (dtRssItem.image == null) || (dtRssItem.image.Length < 5) ? null : dtRssItem.image.Substring (0, dtRssItem.image.Length - 1);
            dtRssItem.date = rssItem.PubDateParsed;
            return dtRssItem;
        }
    }

    // converts datatypes to classes

    public class DTToClass
    {
        public static Convocatoria DTToMeeting (DTMeeting dtMeeting)
        {
            Convocatoria meeting = new Convocatoria();
            meeting.id = dtMeeting.id;
            meeting.idMovimiento = dtMeeting.idMovement;
            meeting.titulo = dtMeeting.name;
            meeting.descripcion = dtMeeting.description;
            // *** ARREGLAR las coordenadas de la base de datos. ***
            meeting.latitud = dtMeeting.locationLati;
            meeting.longitud = dtMeeting.locationLong;
            meeting.minQuorum = dtMeeting.minQuorum;
            return meeting;
        }

        public static Movimiento DTToMovement(DTMovement dtMovement)
        {
            Movimiento movement = new Movimiento();
            movement.id = dtMovement.id;
            movement.nombre = dtMovement.name;
            movement.descripcion = dtMovement.description;
            movement.latitud = dtMovement.locationLati;
            movement.longitud = dtMovement.locationLong;
            movement.idLayout = dtMovement.idLayout;
            return movement;
        }

        /*
        public static RssItem DTToRssItem(DTRssItem dtRssItem)
        {
            RssItem rssItem = new RssItem();
            rssItem.Title = dtRssItem.title;
            rssItem.Description = dtRssItem.description;
            rssItem.Link = dtRssItem.link;
            rssItem.PubDate = dtRssItem.date;
            return rssItem;
        }
         * */
    }

}
