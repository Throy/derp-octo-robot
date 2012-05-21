﻿using System.Collections.ObjectModel;
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
            ControllersHub.Instance.getIMeetingsController().createMeeting(DTToClass.DTToMeeting(dtMeeting));
        }

        // returns all meetings
        public DTMeetingsCol getMeetingsList()
        {
            // create new meetings datatype collection
            DTMeetingsCol dtMeetingsCol = new DTMeetingsCol();
            dtMeetingsCol.items = new Collection<DTMeeting>();

            // get meetings from the controller
            Collection<Convocatoria> meetingsCol = ControllersHub.Instance.getIMeetingsController().getMeetingsList();

            // add meetings to the datatype collection
            foreach (Convocatoria meeting in meetingsCol)
            {
                dtMeetingsCol.items.Add (ClassToDT.MeetingToDT (meeting));
            }

            // return the collection
            return dtMeetingsCol;
        }

        // returns all meetings that the user will attend or didn't confirm.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.RegUser)]
        public DTMeetingsCol getMeetingsListOnAttend()
        {
            // create new meetings datatype collection
            DTMeetingsCol dtMeetingsCol = new DTMeetingsCol();
            dtMeetingsCol.items = new Collection<DTMeeting>();

            // get meetings from the controller
            Collection<Convocatoria> meetingsCol = ControllersHub.Instance.getIMeetingsController().getMeetingsListOnAttend();

            // add meetings to the datatype collection
            foreach (Convocatoria meeting in meetingsCol)
            {
                dtMeetingsCol.items.Add(ClassToDT.MeetingToDT(meeting));
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
