using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;
using RssToolkit.Rss;

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
        public String description { get; set; }

        [DataMember]
        public float locationLati { get; set; }

        [DataMember]
        public float locationLong { get; set; }

        [DataMember]
        public String adminNick { get; set; }

        [DataMember]
        public String adminPassword { get; set; }

        [DataMember]
        public String adminMail { get; set; }
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
        public String sourceText { get; set; }

        [DataMember]
        public String sourceUrl { get; set; }

        [DataMember]
        public String date { get; set; }
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
        public static DTMeeting MeetingToDT (Convocatoria meeting)
        {
            DTMeeting dtMeeting = new DTMeeting();
            dtMeeting.id = meeting.id;
            dtMeeting.idMovement = meeting.idMovimiento;
            dtMeeting.name = meeting.titulo;
            dtMeeting.description = meeting.descripcion;

            dtMeeting.locationLati = meeting.latitud;
            dtMeeting.locationLong = meeting.longitud;
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
            return dtMovement;
        }

        public static DTRssItem RssItemToDT(RssItem rssItem)
        {
            DTRssItem dtRssItem = new DTRssItem();
            dtRssItem.title = rssItem.Title;
            //Regex.Replace(rssItem.Description, @"<(.|\n)*?>", string.Empty, RegexOptions.IgnorePatternWhitespace);
            dtRssItem.description = rssItem.Description;
            dtRssItem.sourceText = (rssItem.Source == null) ? "" : rssItem.Source.Text;
            dtRssItem.sourceUrl = (rssItem.Source == null) ? "" : rssItem.Source.Url;
            dtRssItem.date = rssItem.PubDate;
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
            return movement;
        }

        /*
        public static RssItem DTToRssItem(DTRssItem dtRssItem)
        {
            RssItem rssItem = new RssItem();
            rssItem.Title = dtRssItem.title;
            rssItem.Description = dtRssItem.description;
            rssItem.Source.Text = dtRssItem.sourceText;
            rssItem.Source.Url = dtRssItem.sourceUrl;
            rssItem.PubDate = dtRssItem.date;
            return rssItem;
        }
         * */
    }

}
