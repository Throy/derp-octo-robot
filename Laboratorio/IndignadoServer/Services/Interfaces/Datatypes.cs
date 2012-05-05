using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Classes;

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
        public String name { get; set; }

        [DataMember]
        public String description { get; set; }

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
        public string locationLati { get; set; }

        [DataMember]
        public string locationLong { get; set; }

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

    // **********
    // conversors
    // **********

    // converts classes to datatypes

    public class ClassToDT
    {
        public static DTMeeting MeetingToDT (Meeting meeting)
        {
            DTMeeting dtMeeting = new DTMeeting();
            dtMeeting.id = meeting.id;
            dtMeeting.name = meeting.name;
            dtMeeting.description = meeting.description;
            dtMeeting.minQuorum = meeting.minQuorum;
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
    }

    // converts datatypes to classes

    public class DTToClass
    {
        public static Meeting MeetingToDT (DTMeeting dtMeeting)
        {
            Meeting meeting = new Meeting();
            meeting.id = dtMeeting.id;
            meeting.name = dtMeeting.name;
            meeting.description = dtMeeting.description;
            meeting.minQuorum = dtMeeting.minQuorum;
            return meeting;
        }

        public static Movimiento MovementToDT(DTMovement dtMovement)
        {
            Movimiento movement = new Movimiento();
            movement.nombre = dtMovement.name;
            movement.descripcion = dtMovement.description;
            movement.latitud = dtMovement.locationLati;
            movement.longitud = dtMovement.locationLong;
            return movement;
        }
    }

}
