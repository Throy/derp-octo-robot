using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.Classes;

namespace IndignadoServer.Services
{
    // MeetingsService implements all the services of the Meetings subsystem.

    public class MeetingsService : IMeetingsService
    {
        // ***************
        // service methods
        // ***************

        // returns a meeting
        /*
        public DTMeeting getMeeting()
        {
            // get meetings collection
            Collection<Meeting> meetingsCol = Persistence.getInstance().getMeetings();

            // get the first meeting of the collection
            if (meetingsCol.Count > 0)
            {
                return ClassToDT.MeetingToDT(meetingsCol [0]);
            }

            // meeting not found
            else {
                return null;
            }
        }
         * */

        // returns a meeting
        public DTMeeting getMeeting (int index)
        {
            // get meetings collection
            Collection<Meeting> meetingsCol = Persistence.getInstance().getMeetings();

            // get the asked meeting of the collection
            if (meetingsCol.Count > index)
            {
                return ClassToDT.MeetingToDT(meetingsCol[index]);
            }

            // meeting not found
            else
            {
                return null;
            }
        }

        // adds a meeting (berreta)
        /*
        public void addEmptyMeeting()
        {
            Collection<Meeting> meetingsCol = Persistence.getInstance().getMeetings();
            Meeting newMeeting = Persistence.getInstance().newMeeting (Persistence.getInstance().getMeetings().Count);
            meetingsCol.Add (newMeeting);
        }
         * */

        // creates a meeting
        public void createMeeting (DTMeeting dtMeeting)
        {
            // get meetings collection
            Collection<Meeting> meetingsCol = Persistence.getInstance().getMeetings();

            // set new id (berreta)
            dtMeeting.id = Persistence.getInstance().getMeetings().Count;

            // add the new meeting to the collection
            meetingsCol.Add (DTToClass.MeetingToDT (dtMeeting));
        }

        // returns all meetings
        public DTMeetingsCol getMeetingsList()
        {
            /* berreta
            DTMeetingsCol newMeetings = new DTMeetingsCol();
            newMeetings.items = new Collection<DTMeeting>();

            DTMeeting newMeeting1 = getMeeting (1);
            newMeetings.items.Add (newMeeting1);

            DTMeeting newMeeting2 = getMeeting (2);
            newMeetings.items.Add (newMeeting2);

            return newMeetings;
             * */


            // get meetings collection
            Collection<Meeting> meetingsCol = Persistence.getInstance().getMeetings();

            // create new meetings datatype collection
            DTMeetingsCol dtMeetingsCol = new DTMeetingsCol();

            // add meetings datatypes to the collection
            dtMeetingsCol.items = new Collection<DTMeeting>();
            foreach (Meeting meeting in meetingsCol)
            {
                dtMeetingsCol.items.Add (ClassToDT.MeetingToDT (meeting));
            }

            // return the collection
            return dtMeetingsCol;
        }
    }
}
