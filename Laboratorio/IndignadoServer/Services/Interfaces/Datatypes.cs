using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using IndignadoServer.LinqDataContext;
using RssToolkit.Rss;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

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

        [DataMember]
        public String imagePath { get; set; }
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

    // Resource datatype
    [DataContract]
    public class DTResource
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int idUser { get; set; }

        [DataMember]
        public String title { get; set; }

        [DataMember]
        public String description { get; set; }

        [DataMember]
        public String link { get; set; }

        [DataMember]
        public String thumbnail { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public int numberLikes { get; set; }
    }

    // Resource Collection datatype
    [DataContract]
    public class DTResourcesCol
    {
        [DataMember]
        public Collection<DTResource> items { get; set; }
    }

    public class DTRegisterModel
    {
        [DataMember]
        public int idMovimiento { get; set; }

        [DataMember]
        public String nombre { get; set; }

        [DataMember]
        public String apodo { get; set; }

        [DataMember]
        public String mail { get; set; }

        [DataMember]
        public String contraseña { get; set; }

        [DataMember]
        public float latitud { get; set; }

        [DataMember]
        public float longitud { get; set; }
    }

    // Summary:
    //     Describes the result of a Session Controller register user
    //     operation
    public enum DTUserCreateStatus
    {
        // Summary:
        //     The user was successfully created.
        Success = 0,
        //
        // Summary:
        //     The user name was not found in the database.
        InvalidUserName = 1,
        //
        // Summary:
        //     The password is not formatted correctly.
        InvalidPassword = 2,
        //
        // Summary:
        //     The e-mail address is not formatted correctly.
        InvalidEmail = 5,
        //
        // Summary:
        //     The user name already exists in the database for the application.
        DuplicateUserName = 6,
        //
        // Summary:
        //     The e-mail address already exists in the database for the application.
        DuplicateEmail = 7,
        //
        // Summary:
        //     Hubo algun error, solo porque todavia no estan hechos los errores
        GenericError = 8,
    }


    // RssSource datatype
    [DataContract]
    public class DTRssSource
    {
        [DataMember]
        public String url { get; set; }

        [DataMember]
        public String tag { get; set; }
    }

    // RssSources Collection datatype
    [DataContract]
    public class DTRssSourcesCol
    {
        [DataMember]
        public Collection<DTRssSource> items { get; set; }
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
            dtMeeting.imagePath = meeting.logo;
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

        public static DTResource ResourceToDT(Recurso resource)
        {
            DTResource dtResource = new DTResource();
            dtResource.id = resource.id;
            dtResource.idUser = resource.idUsuario;
            dtResource.title = resource.titulo;
            dtResource.description = resource.descripcion;
            dtResource.link = resource.link;
            dtResource.thumbnail = resource.logo;
            dtResource.date = (resource.fecha == null) ? new DateTime() : resource.fecha.Value;
            dtResource.numberLikes = 0;
            return dtResource;
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
            meeting.logo = dtMeeting.imagePath;
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

        public static Recurso DTToResource(DTResource dtResource)
        {
            Recurso resource = new Recurso();
            resource.id = dtResource.id;
            resource.idUsuario = dtResource.idUser;
            resource.titulo = dtResource.title;
            resource.descripcion = dtResource.description;
            resource.link = dtResource.link;
            resource.logo = dtResource.thumbnail;
            resource.fecha = dtResource.date;
            return resource;
        }

        public static Usuario DTToUsuario(DTRegisterModel dtUser)
        {
            Usuario user = new Usuario();
            user.idMovimiento = dtUser.idMovimiento;
            user.latitud = dtUser.latitud;
            user.longitud = dtUser.longitud;
            user.mail = dtUser.mail;
            user.nombre = dtUser.nombre;
            user.apodo = dtUser.apodo;

            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] passwordHash = sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(dtUser.contraseña));
            user.contraseña = passwordHash;

            return user;
        }

    }

}
