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

        [DataMember]
        public DateTime dateBegin { get; set; }

        [DataMember]
        public DateTime dateEnd { get; set; }

        [DataMember]
        public Collection<DTThemeCategoryMeetings> themeCategories { get; set; }

        [DataMember]
        public int numberAttendants { get; set; }

        [DataMember]
        public int myAttendance { get; set; }

        [DataMember]
        public bool isConfirmed { get; set; }

        [DataMember]
        public bool isActive { get; set; }
    }

    // Meeting Collection datatype
    [DataContract]
    public class DTMeetingsCol
    {
        [DataMember]
        public Collection<DTMeeting> items { get; set; }
    }

    // Meeting Notification datatype
    [DataContract]
    public class DTMeetingNotification : DTMeeting
    {
    }

    // Meeting Notification Collection datatype
    [DataContract]
    public class DTMeetingsNotificationsCol
    {
        [DataMember]
        public Collection<DTMeetingNotification> items { get; set; }
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

        [DataMember]
        public String imagePath { get; set; }

        [DataMember]
        public String subURL { get; set; }

        [DataMember]
        public int maxMarcasInadecuadasRecursoX { get; set; }

        [DataMember]
        public int maxRecursosInadecuadosUsuarioZ { get; set; }

        [DataMember]
        public int maxRecursosPopularesN { get; set; }

        [DataMember]
        public int maxUltimosRecursosM { get; set; }



    }

    [DataContract]
    public class DTLayout
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String name { get; set; }
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
        public String sourceUrl { get; set; }

        [DataMember]
        public String sourceTitle { get; set; }

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
        public String username { get; set; }

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
        public int numberMarksInappr { get; set; }

        [DataMember]
        public int myMarkInappr { get; set; }

        [DataMember]
        public int disabled { get; set; }
    }
    

    // Resource datatype - NewsResources
    [DataContract]
    public class DTResource_NewsResources : DTResource
    {
    }

    // Resource Collection datatype - NewsResources
    [DataContract]
    public class DTResourcesCol_NewsResources
    {
        [DataMember]
        public Collection<DTResource_NewsResources> items { get; set; }
    }

    // Resource datatype - MovAdmin
    [DataContract]
    public class DTResource_MovAdmin : DTResource
    {
    }

    // Resource Collection datatype - MovAdmin
    [DataContract]
    public class DTResourcesCol_MovAdmin
    {
        [DataMember]
        public Collection<DTResource_MovAdmin> items { get; set; }
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

        [DataMember]
        public String title { get; set; }
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
        public DTLoginInfo(String name, int id, String token, bool isRegUser, bool isMovAdmin, bool isSysAdmin)
        {
            this.name = name;
            this.id = id;
            this.token = token;
            this.isRegUser = isRegUser;
            this.isMovAdmin = isMovAdmin;
            this.isSysAdmin = isSysAdmin;
        }

        [DataMember]
        public String name { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String token { get; set; }

        [DataMember]
        public bool isRegUser { get; set; }

        [DataMember]
        public bool isMovAdmin { get; set; }

        [DataMember]
        public bool isSysAdmin { get; set; }
    }

    public enum DTLoginFaultType
    {
        // Unknown Username or Incorrect Password
        UNKOWN_OR_INVALID = 0,
        // El usuario de facebook no se encuentra registrado
        FB_NOT_REGISTERED = 1,
        // El usuario de está deshabilitado
        BANNED = 2
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

    // User datatype
    [DataContract]
    public class DTUser
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String username { get; set; }

        [DataMember]
        public String fullName { get; set; }

        [DataMember]
        public String mail { get; set; }

        [DataMember]
        public DateTime registerDate { get; set; }

        [DataMember]
        public float locationLati { get; set; }

        [DataMember]
        public float locationLong { get; set; }

        [DataMember]
        public int numberResourcesMarkedInappr { get; set; }

        [DataMember]
        public int numberResourcesDisabled { get; set; }

        [DataMember]
        public bool banned { get; set; }
    }

    // User datatype - MovAdminController
    [DataContract]
    public class DTUser_MovAdmin: DTUser
    {
    }

    // Users Collection datatype - MovAdminController
    [DataContract]
    public class DTUsersCol_MovAdmin
    {
        [DataMember]
        public Collection<DTUser_MovAdmin> items { get; set; }
    }

    // User datatype - UsersController
    [DataContract]
    public class DTUser_Users : DTUser
    {
    }

    // User Details datatype - MovAdminController
    [DataContract]
    public class DTUserDetails_MovAdmin
    {
        [DataMember]
        public DTUser_MovAdmin user { get; set; }

        [DataMember]
        public Collection<DTResource_MovAdmin> resources { get; set; }
    }

    [DataContract]
    public class DTChatMessage
    {
        [DataMember]
        public int fromId { get; set; }

        [DataMember]
        public String from { get; set; }

        [DataMember]
        public int type { get; set; }

        [DataMember]
        public String message { get; set; }

        [DataMember]
        public DTChatRoom room { get; set; }
    }

    [DataContract]
    public class DTChatRoom
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String title { get; set; }
    }

    [DataContract]
    public class DTChatUser
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String nick { get; set; }

        [DataMember]
        public bool active { get; set; }
    }

    // Users RegisterReport datatype
    [DataContract]
    public class DTUsersRegisterReport
    {
        [DataMember]
        public DTUsersRegisterReport_PeriodType periodType { get; set; }

        [DataMember]
        public Collection<DTUsersRegisterReportItem> items { get; set; }
    }

    // Users RegisterReport Item datatype
    [DataContract]
    public class DTUsersRegisterReportItem
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String period { get; set; }
        
        [DataMember]
        public int numberRegisters { get; set; }
        
        [DataMember]
        public int numberUsers { get; set; }
    }
    
    // Users RegisterReport Period Type enum
    public enum DTUsersRegisterReport_PeriodType
    {
        Year = 0,
        Month = 1,
        Day = 2
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
            dtMeeting.description = meeting.descripcion + " ";
            dtMeeting.locationLati = (float)meeting.latitud;
            dtMeeting.locationLong = (float)meeting.longitud;
            dtMeeting.minQuorum = meeting.minQuorum == null? 0: meeting.minQuorum.Value;
            dtMeeting.imagePath = meeting.logo;
            dtMeeting.dateBegin = meeting.fechaInicio;
            dtMeeting.dateEnd = meeting.fechaFin;
            dtMeeting.numberAttendants = meeting.cantAsistencias == null ? 0 : meeting.cantAsistencias.Value;
            dtMeeting.myAttendance = meeting.miAsistencia == null ? 0 : meeting.miAsistencia.Value;
            dtMeeting.isConfirmed = meeting.estaConfirmada == null ? false : meeting.estaConfirmada.Value;
            dtMeeting.isActive = meeting.estaActiva == null ? false : meeting.estaActiva.Value;
            dtMeeting.imagePath = meeting.logo == null ? "" : meeting.logo;
            return dtMeeting;
        }

        public static DTMeetingNotification MeetingNotificationToDT(Convocatoria meeting)
        {
            DTMeetingNotification dtMeetingNotification = new DTMeetingNotification();
            dtMeetingNotification.id = meeting.id;
            dtMeetingNotification.idMovement = meeting.idMovimiento;
            dtMeetingNotification.name = meeting.titulo;
            dtMeetingNotification.description = meeting.descripcion + " ";
            dtMeetingNotification.locationLati = (float)meeting.latitud;
            dtMeetingNotification.locationLong = (float)meeting.longitud;
            dtMeetingNotification.minQuorum = meeting.minQuorum == null ? 0 : meeting.minQuorum.Value;
            dtMeetingNotification.imagePath = meeting.logo;
            dtMeetingNotification.dateBegin = meeting.fechaInicio;
            dtMeetingNotification.dateEnd = meeting.fechaFin;
            dtMeetingNotification.numberAttendants = meeting.cantAsistencias == null ? 0 : meeting.cantAsistencias.Value;
            dtMeetingNotification.myAttendance = meeting.miAsistencia == null ? 0 : meeting.miAsistencia.Value;
            dtMeetingNotification.isConfirmed = meeting.estaConfirmada == null ? false : meeting.estaConfirmada.Value;
            dtMeetingNotification.isActive = meeting.estaActiva == null ? false : meeting.estaActiva.Value;
            dtMeetingNotification.imagePath = meeting.logo == null ? "" : meeting.logo;
            return dtMeetingNotification;
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
            dtMovement.imagePath = movement.logo;
            dtMovement.subURL = movement.url;
            dtMovement.maxMarcasInadecuadasRecursoX = movement.maxMarcasInadecuadasRecursoX;
            dtMovement.maxRecursosInadecuadosUsuarioZ = movement.maxRecursosInadecuadosUsuarioZ;
            dtMovement.maxRecursosPopularesN = movement.maxRecursosPopularesN;
            dtMovement.maxUltimosRecursosM = movement.maxUltimosRecursosM;
            return dtMovement;
        }

        public static DTLayout LayoutToDT(Layout layout)
        {
            DTLayout dtLayout = new DTLayout();
            dtLayout.id = layout.id;
            dtLayout.name = layout.name;

            return dtLayout;
        }

        public static DTRssItem RssItemToDT(RssItem rssItem)
        {
            DTRssItem dtRssItem = new DTRssItem();
            dtRssItem.title = rssItem.Title;
            //dtRssItem.description = Regex.Replace(rssItem.Description, @"</?(a|img|div|p|strong) ?[^>]*?>", string.Empty);
            // Le puse para que quite todas las tags, sino quedaba el br y me movia todo de lugar
            dtRssItem.description = Regex.Replace(rssItem.Description, "<(.|\\n)*?>", string.Empty);
            dtRssItem.sourceUrl = (rssItem.Link == null) ? "" : rssItem.Link;
            dtRssItem.sourceTitle = "";
            // Le agregue jpg para que no capture unos gifs transparentes que no mostraban nada
            dtRssItem.image = Regex.Match(rssItem.Description, @"<img[^>]*jpg.*?/>").Value;
            dtRssItem.image = (dtRssItem.image == null) ? null : Regex.Match(dtRssItem.image, @"src\=\"".*?\""").Value;
            dtRssItem.image = (dtRssItem.image == null) || (dtRssItem.image.Length < 5) ? null : dtRssItem.image.Substring(5);
            dtRssItem.image = (dtRssItem.image == null) || (dtRssItem.image.Length < 5) ? null : dtRssItem.image.Substring (0, dtRssItem.image.Length - 1);
            dtRssItem.date = rssItem.PubDateParsed;
            return dtRssItem;
        }

        public static DTResource_NewsResources ResourceToDT_NewsResources(Recurso resource)
        {
            DTResource_NewsResources dtResource = new DTResource_NewsResources();
            dtResource.id = resource.id;
            dtResource.idUser = resource.idUsuario;
            dtResource.username = resource.apodoUsuario;
            dtResource.title = resource.titulo;
            dtResource.description = resource.descripcion;
            dtResource.urlLink = resource.urlLink;
            dtResource.urlImage = resource.urlImage;
            dtResource.urlVideo = resource.urlVideo;
            dtResource.urlThumb = resource.urlThumb;
            dtResource.date = (resource.fecha == null) ? new DateTime() : resource.fecha.Value;
            dtResource.numberLikes = (resource.cantAprobaciones == null) ? 0 : resource.cantAprobaciones.Value;
            dtResource.iLikeIt = (resource.meGusta == null) ? 0 : resource.meGusta.Value;
            dtResource.numberMarksInappr = (resource.cantMarcasInadecuado == null) ? 0 : resource.cantMarcasInadecuado.Value;
            dtResource.myMarkInappr = (resource.yoMarqueInadecuado == null) ? 0 : resource.yoMarqueInadecuado.Value;
            dtResource.disabled = (resource.deshabilitado == null) ? 0 : resource.deshabilitado.Value;
            return dtResource;
        }

        public static DTResource_MovAdmin ResourceToDT_MovAdmin(Recurso resource)
        {
            DTResource_MovAdmin dtResource = new DTResource_MovAdmin();
            dtResource.id = resource.id;
            dtResource.idUser = resource.idUsuario;
            dtResource.username = resource.apodoUsuario;
            dtResource.title = resource.titulo;
            dtResource.description = resource.descripcion;
            dtResource.urlLink = resource.urlLink;
            dtResource.urlImage = resource.urlImage;
            dtResource.urlVideo = resource.urlVideo;
            dtResource.urlThumb = resource.urlThumb;
            dtResource.date = (resource.fecha == null) ? new DateTime() : resource.fecha.Value;
            dtResource.numberLikes = (resource.cantAprobaciones == null) ? 0 : resource.cantAprobaciones.Value;
            dtResource.iLikeIt = (resource.meGusta == null) ? 0 : resource.meGusta.Value;
            dtResource.numberMarksInappr = (resource.cantMarcasInadecuado == null) ? 0 : resource.cantMarcasInadecuado.Value;
            dtResource.myMarkInappr = (resource.yoMarqueInadecuado == null) ? 0 : resource.yoMarqueInadecuado.Value;
            dtResource.disabled = (resource.deshabilitado == null) ? 0 : resource.deshabilitado.Value;
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

        public static DTUser_MovAdmin UserToDT_MovAdmin(Usuario user)
        {
            DTUser_MovAdmin dtUser = new DTUser_MovAdmin();
            dtUser.id = user.id;
            dtUser.username = user.apodo;
            dtUser.fullName = user.nombre;
            dtUser.mail = user.mail;
            dtUser.registerDate = (user.fechaRegistro == null) ? new DateTime() : user.fechaRegistro.Value;
            dtUser.locationLati = (float)user.latitud;
            dtUser.locationLong = (float)user.longitud;
            dtUser.numberResourcesMarkedInappr = (user.cantRecursosMarcadosInadecuados == null) ? 0 : user.cantRecursosMarcadosInadecuados.Value;
            dtUser.numberResourcesDisabled = (user.cantRecursosDeshabilitados == null) ? 0 : user.cantRecursosDeshabilitados.Value;
            dtUser.banned = user.banned;
            return dtUser;
        }

        public static DTUser_Users UserToDT_Users(Usuario user)
        {
            DTUser_Users dtUser = new DTUser_Users();
            dtUser.id = user.id;
            dtUser.username = user.apodo;
            dtUser.fullName = user.nombre;
            dtUser.mail = user.mail;
            dtUser.registerDate = (user.fechaRegistro == null) ? new DateTime() : user.fechaRegistro.Value;
            dtUser.locationLati = (float)user.latitud;
            dtUser.locationLong = (float)user.longitud;
            dtUser.numberResourcesMarkedInappr = (user.cantRecursosMarcadosInadecuados == null) ? 0 : user.cantRecursosMarcadosInadecuados.Value;
            dtUser.numberResourcesDisabled = (user.cantRecursosDeshabilitados == null) ? 0 : user.cantRecursosDeshabilitados.Value;
            dtUser.banned = user.banned;
            return dtUser;
        }

        public static DTChatMessage MessageToDT(ChatMessage m, String roomTitle)
        {
            DTChatMessage result = new DTChatMessage();
            result.from = m.SenderNick;
            result.fromId = m.Sender;
            result.message = m.Message;
            result.room = new DTChatRoom();
            result.room.id = m.Room;
            result.room.title = roomTitle;
            result.type = m.Type;
            return result;
        }

        public static DTChatUser ChatUserToDT(ChatUser u)
        {
            DTChatUser dt = new DTChatUser();
            dt.id = u.id;
            dt.nick = u.nick;
            dt.active = u.active;

            return dt;
        }

        public static DTRssSource RssSourceToDT(RssFeed rssSource)
        {
            DTRssSource dtRssSource = new DTRssSource();
            dtRssSource.url = rssSource.url;
            dtRssSource.tag = rssSource.tag;
            dtRssSource.title = rssSource.titulo;
            return dtRssSource;

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
            meeting.logo = dtMeeting.imagePath;
            meeting.fechaInicio = dtMeeting.dateBegin;
            meeting.fechaFin = dtMeeting.dateEnd;
            meeting.cantAsistencias = dtMeeting.numberAttendants;
            meeting.miAsistencia = dtMeeting.myAttendance;
            meeting.estaConfirmada = dtMeeting.isConfirmed;
            meeting.estaActiva = dtMeeting.isActive;
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
            movement.logo = dtMovement.imagePath;
            movement.url = dtMovement.subURL;
            movement.maxMarcasInadecuadasRecursoX = dtMovement.maxMarcasInadecuadasRecursoX;
            movement.maxRecursosInadecuadosUsuarioZ = dtMovement.maxRecursosInadecuadosUsuarioZ;
            movement.maxRecursosPopularesN = dtMovement.maxRecursosPopularesN;
            movement.maxUltimosRecursosM = dtMovement.maxUltimosRecursosM;
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
            resource.apodoUsuario = dtResource.username;
            resource.titulo = dtResource.title;
            resource.descripcion = dtResource.description;
            resource.urlLink = dtResource.urlLink;
            resource.urlImage = dtResource.urlImage;
            resource.urlVideo = dtResource.urlVideo;
            resource.urlThumb = dtResource.urlThumb;
            resource.fecha = dtResource.date;
            resource.cantAprobaciones = dtResource.numberLikes;
            resource.meGusta = dtResource.iLikeIt;
            resource.cantMarcasInadecuado = dtResource.numberMarksInappr;
            resource.yoMarqueInadecuado = dtResource.myMarkInappr;
            resource.deshabilitado = dtResource.disabled;
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

        public static Usuario DTToUser(DTUser dtUser)
        {
            Usuario user = new Usuario();
            user.id = dtUser.id;
            user.apodo = dtUser.username;
            user.nombre = dtUser.fullName;
            user.mail = dtUser.mail;
            user.fechaRegistro = dtUser.registerDate;
            user.latitud = dtUser.locationLati;
            user.longitud = dtUser.locationLong;
            user.cantRecursosMarcadosInadecuados = dtUser.numberResourcesMarkedInappr;
            user.cantRecursosDeshabilitados = dtUser.numberResourcesDisabled;
            user.banned = dtUser.banned;
            return user;
        }

        public static RssFeed DTToRssSource(DTRssSource dtRssSource)
        {
            RssFeed rssSource = new RssFeed();
            rssSource.url = dtRssSource.url;
            rssSource.tag = dtRssSource.tag;
            rssSource.titulo = dtRssSource.title;
            return rssSource;
        }

    }

}
