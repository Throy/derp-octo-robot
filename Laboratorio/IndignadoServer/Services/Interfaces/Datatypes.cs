using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;

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
        public double locationLati { get; set; }

        [DataMember]
        public double locationLong { get; set; }

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
        public static DTMeeting MeetingToDT (Convocatoria meeting)
        {
            DTMeeting dtMeeting = new DTMeeting();
            dtMeeting.id = meeting.id;
            dtMeeting.idMovement = meeting.idMovimiento;
            dtMeeting.name = meeting.titulo;
            dtMeeting.description = meeting.descripcion;
            dtMeeting.minQuorum = meeting.minQuorum == null? 0: meeting.minQuorum.Value;
            return dtMeeting;
        }

        public static DTMovement MovementToDT(Movimiento movement)
        {
            DTMovement dtMovement = new DTMovement();
            dtMovement.id = movement.id;
            dtMovement.name = movement.nombre;
            dtMovement.description = movement.descripcion;
            dtMovement.locationLati = Double.Parse (movement.latitud);
            dtMovement.locationLong = Double.Parse (movement.longitud);
            return dtMovement;
        }
    }

    // converts datatypes to classes

    public class DTToClass
    {
        public static Convocatoria MeetingToDT (DTMeeting dtMeeting)
        {
            Convocatoria meeting = new Convocatoria();
            meeting.id = dtMeeting.id;
            meeting.idMovimiento = dtMeeting.idMovement;
            meeting.titulo = dtMeeting.name;
            meeting.descripcion = dtMeeting.description;
            meeting.minQuorum = dtMeeting.minQuorum;
            return meeting;
        }

        public static Movimiento MovementToDT(DTMovement dtMovement)
        {
            Movimiento movement = new Movimiento();
            movement.nombre = dtMovement.name;
            movement.descripcion = dtMovement.description;
            movement.latitud = dtMovement.locationLati.ToString();
            movement.longitud = dtMovement.locationLong.ToString();
            return movement;
        }
    }

}
