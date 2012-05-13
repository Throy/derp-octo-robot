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
