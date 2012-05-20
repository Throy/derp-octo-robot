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
        public int numberAttendants { get; set; }

        [DataMember]
        public String imagePath { get; set; }

        [DataMember]
        public int myAttendance { get; set; }
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
        public String urlLink { get; set; }

        [DataMember]
        public String urlImage { get; set; }

        [DataMember]
        public String urlVideo { get; set; }

        [DataMember]
        public String urlThumb { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public int numberLikes { get; set; }

        [DataMember]
        public int iLikeIt { get; set; }

        [DataMember]
        public int myMarkInappr { get; set; }
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

    public class DTRegisterFBModel
    {
        [DataMember]
        public int idMovimiento { get; set; }

        [DataMember]
        public float latitud { get; set; }

        [DataMember]
        public float longitud { get; set; }

        [DataMember]
        public String token { get; set; }
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

    // Login info datatype
    [DataContract]
    public class DTLoginInfo
    {
        public DTLoginInfo(String name, String token)
        {
            this.name = name;
            this.token = token;
        }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String token { get; set; }
    }

    public enum DTLoginFaultType
    {
        // Unknown Username or Incorrect Password
        UNKOWN_OR_INVALID = 0,
        // El usuario de facebook no se encuentra registrado
        FB_NOT_REGISTERED = 1
    }

    [DataContract]
    public class LoginFault
    {
        public LoginFault(String issue, DTLoginFaultType type)
        {
            Issue = issue;
            Type = type;
        }

        [DataMember]
        public String Issue { get; set; }


        [DataMember]
        public DTLoginFaultType Type { get; set; }
    }

    // ThemeCategory datatype
    [DataContract]
    public class DTThemeCategory
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int idMovement { get; set; }

        [DataMember]
        public String title { get; set; }

        [DataMember]
        public String description { get; set; }

        [DataMember]
        public int myInterest { get; set; }
    }

    // ThemeCategory datatype
    [DataContract]
    public class DTThemeCategoryMovAdmin : DTThemeCategory
    {
    }

    // ThemeCategories Collection datatype
    [DataContract]
    public class DTThemeCategoriesColMovAdmin
    {
        [DataMember]
        public Collection<DTThemeCategoryMovAdmin> items { get; set; }
    }

    // ThemeCategory datatype
    [DataContract]
    public class DTThemeCategoryUsers : DTThemeCategory
    {
    }

    // ThemeCategories Collection datatype
    [DataContract]
    public class DTThemeCategoriesColUsers
    {
        [DataMember]
        public Collection<DTThemeCategoryUsers> items { get; set; }
    }

    // ThemeCategory datatype
    [DataContract]
    public class DTThemeCategoryMeetings : DTThemeCategory
    {
    }

    // ThemeCategories Collection datatype
    [DataContract]
    public class DTThemeCategoriesColMeetings
    {
        [DataMember]
        public Collection<DTThemeCategoryMeetings> items { get; set; }
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
            dtMeeting.locationLati = (float)meeting.latitud;
            dtMeeting.locationLong = (float)meeting.longitud;
            dtMeeting.minQuorum = meeting.minQuorum == null? 0: meeting.minQuorum.Value;
            dtMeeting.numberAttendants = meeting.cantAsistencias == null ? 0 : meeting.cantAsistencias.Value;
            dtMeeting.imagePath = meeting.logo;
            dtMeeting.myAttendance = meeting.miAsistencia == null ? 0 : meeting.miAsistencia.Value;
            return dtMeeting;
        }

        public static DTMovement MovementToDT(Movimiento movement)
        {
            DTMovement dtMovement = new DTMovement();
            dtMovement.id = movement.id;
            dtMovement.name = movement.nombre;
            dtMovement.description = movement.descripcion;
            dtMovement.locationLati = (float)movement.latitud;
            dtMovement.locationLong = (float)movement.longitud;
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
            dtResource.urlLink = resource.urlLink;
            dtResource.urlImage = resource.urlImage;
            dtResource.urlVideo = resource.urlVideo;
            dtResource.urlThumb = resource.urlThumb;
            dtResource.date = (resource.fecha == null) ? new DateTime() : resource.fecha.Value;
            dtResource.numberLikes = (resource.cantAprobaciones == null) ? 0 : resource.cantAprobaciones.Value;
            dtResource.iLikeIt = (resource.meGusta == null) ? 0 : resource.meGusta.Value;
            dtResource.myMarkInappr = (resource.yoMarqueInadecuado == null) ? 0 : resource.yoMarqueInadecuado.Value;
            return dtResource;
        }

        public static DTThemeCategoryUsers ThemeCategoryToDTUsers(CategoriasTematica themeCategory)
        {
            DTThemeCategoryUsers dtThemeCategory = new DTThemeCategoryUsers();
            dtThemeCategory.id = themeCategory.id;
            dtThemeCategory.idMovement = themeCategory.idMovimiento;
            dtThemeCategory.title = themeCategory.titulo;
            dtThemeCategory.description = themeCategory.descripcion;
            dtThemeCategory.myInterest = (themeCategory.miInteres == null) ? 0 : themeCategory.miInteres.Value;
            return dtThemeCategory;
        }

        public static DTThemeCategoryMovAdmin ThemeCategoryToDTMovAdmin(CategoriasTematica themeCategory)
        {
            DTThemeCategoryMovAdmin dtThemeCategory = new DTThemeCategoryMovAdmin();
            dtThemeCategory.id = themeCategory.id;
            dtThemeCategory.idMovement = themeCategory.idMovimiento;
            dtThemeCategory.title = themeCategory.titulo;
            dtThemeCategory.description = themeCategory.descripcion;
            dtThemeCategory.myInterest = (themeCategory.miInteres == null) ? 0 : themeCategory.miInteres.Value;
            return dtThemeCategory;
        }

        public static DTThemeCategoryMeetings ThemeCategoryToDTMeetings(CategoriasTematica themeCategory)
        {
            DTThemeCategoryMeetings dtThemeCategory = new DTThemeCategoryMeetings();
            dtThemeCategory.id = themeCategory.id;
            dtThemeCategory.idMovement = themeCategory.idMovimiento;
            dtThemeCategory.title = themeCategory.titulo;
            dtThemeCategory.description = themeCategory.descripcion;
            dtThemeCategory.myInterest = (themeCategory.miInteres == null) ? 0 : themeCategory.miInteres.Value;
            return dtThemeCategory;
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
            meeting.latitud = dtMeeting.locationLati;
            meeting.longitud = dtMeeting.locationLong;
            meeting.minQuorum = dtMeeting.minQuorum;
            meeting.cantAsistencias = dtMeeting.numberAttendants;
            meeting.miAsistencia = dtMeeting.myAttendance;
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
            resource.urlLink = dtResource.urlLink;
            resource.urlImage = dtResource.urlImage;
            resource.urlVideo = dtResource.urlVideo;
            resource.urlThumb = dtResource.urlThumb;
            resource.fecha = dtResource.date;
            resource.cantAprobaciones = dtResource.numberLikes;
            resource.meGusta = dtResource.iLikeIt;
            resource.yoMarqueInadecuado = dtResource.myMarkInappr;
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

        public static CategoriasTematica DTToThemeCategory(DTThemeCategory dtThemeCategory)
        {
            CategoriasTematica themeCategory = new CategoriasTematica();
            themeCategory.id = dtThemeCategory.id;
            themeCategory.idMovimiento = dtThemeCategory.idMovement;
            themeCategory.titulo = dtThemeCategory.title;
            themeCategory.descripcion = dtThemeCategory.description;
            themeCategory.miInteres = dtThemeCategory.myInterest;
            return themeCategory;
        }
    }

}
