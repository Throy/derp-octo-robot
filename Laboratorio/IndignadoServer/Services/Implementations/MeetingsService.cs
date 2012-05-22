using System.Collections.ObjectModel;
using System.Security.Permissions;
using IndignadoServer.Controllers;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Services
{
    // MeetingsService implements all the services of the Meetings subsystem.

    public class MeetingsService : IMeetingsService
    {
        // ***************
        // service methods
        // ***************


        // returns a meeting
        public DTMeeting getMeeting (int idMeeting)
        {
            try
            {
                return ClassToDT.MeetingToDT(ControllersHub.Instance.getIMeetingsController().getMeeting(idMeeting));
            }
            catch { 
                return null;
            }
        }

        // creates a meeting
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void createMeeting (DTMeeting dtMeeting)
        {
            // create the theme categories collection.
            Collection<CategoriasTematica> themeCategories = new Collection<CategoriasTematica>();
            foreach (DTThemeCategoryMeetings dtThemeCat in dtMeeting.themeCategories) {
                themeCategories.Add(DTToClass.DTToThemeCategory(dtThemeCat));
            }
            
            // create the meeting.
            ControllersHub.Instance.getIMeetingsController().createMeeting(DTToClass.DTToMeeting(dtMeeting), themeCategories);
        }

        // returns all meetings
        public DTMeetingsCol getMeetingsList()
        {
            return MeetingsColToDT(ControllersHub.Instance.getIMeetingsController().getMeetingsList());
        }

        // returns all meetings that the user will attend or didn't confirm.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public DTMeetingsCol getMeetingsListOnAttend()
        {
            return MeetingsColToDT (ControllersHub.Instance.getIMeetingsController().getMeetingsListOnAttend());
        }

        // returns all meetings that the user is interested in.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public DTMeetingsCol getMeetingsListOnInterest()
        {
            return MeetingsColToDT(ControllersHub.Instance.getIMeetingsController().getMeetingsListOnInterest());
        }

        // converts a meetings collection to a datatype.
        public static DTMeetingsCol MeetingsColToDT(Collection<Convocatoria> meetingsCol)
        {
            // create new meetings datatype collection
            DTMeetingsCol dtMeetingsCol = new DTMeetingsCol();
            dtMeetingsCol.items = new Collection<DTMeeting>();

            // add meetings to the datatype collection
            foreach (Convocatoria meeting in meetingsCol)
            {
                // convert to datatype
                DTMeeting dtMeeting = ClassToDT.MeetingToDT(meeting);

                // add theme categories.
                Collection<CategoriasTematica> themeCats = ControllersHub.Instance.getIMeetingsController().getThemeCategoriesMeeting(meeting);
                dtMeeting.themeCategories = new Collection<DTThemeCategoryMeetings>();
                foreach (CategoriasTematica themeCat in themeCats)
                {
                    dtMeeting.themeCategories.Add(ClassToDT.ThemeCategoryToDTMeetings(themeCat));
                }

                // add meetings to the datatype collection.
                dtMeetingsCol.items.Add(dtMeeting);
            }

            // return the collection
            return dtMeetingsCol;
        }

        // returns all theme categories.
        public DTThemeCategoriesColMeetings getThemeCategoriesList()
        {
            // create new theme categories datatype collection
            DTThemeCategoriesColMeetings dtThemeCategoriesCol = new DTThemeCategoriesColMeetings();
            dtThemeCategoriesCol.items = new Collection<DTThemeCategoryMeetings>();

            // get theme categories from the controller
            Collection<CategoriasTematica> themeCategoriesCol = ControllersHub.Instance.getIMeetingsController().getThemeCategoriesList();

            // add theme categories to the datatype collection
            foreach (CategoriasTematica themeCategory in themeCategoriesCol)
            {
                dtThemeCategoriesCol.items.Add(ClassToDT.ThemeCategoryToDTMeetings(themeCategory));
            }

            // return the collection
            return dtThemeCategoriesCol;
        }

        // do attend a meeting.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void doAttendMeeting(DTMeeting dtMeeting)
        {
            ControllersHub.Instance.getIMeetingsController().doAttendMeeting(DTToClass.DTToMeeting(dtMeeting));
        }

        // unconfirm attendace to a meeting.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void unconfirmAttendMeeting(DTMeeting dtMeeting)
        {
            ControllersHub.Instance.getIMeetingsController().unconfirmAttendanceMeeting(DTToClass.DTToMeeting(dtMeeting));
        }

        // don't attend a meeting.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public void dontAttendMeeting(DTMeeting dtMeeting)
        {
            ControllersHub.Instance.getIMeetingsController().dontAttendMeeting(DTToClass.DTToMeeting(dtMeeting));
        }
    }
}
