using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer
{
    // MeetingsService implements all the services of the Meetings subsystem.

    public class MeetingsService : IMeetingsService
    {
        // ***************
        // service methods
        // ***************

        // returns a meeting
        public DTMeeting getMeeting()
        {
            return getMeeting (1);
        }

        // returns all meetings
        public DTMeetingsCol getMeetingsList()
        {
            DTMeetingsCol newMeetings = new DTMeetingsCol();
            newMeetings.items = new Collection<DTMeeting>();

            DTMeeting newMeeting1 = getMeeting (1);
            newMeetings.items.Add (newMeeting1);

            DTMeeting newMeeting2 = getMeeting (2);
            newMeetings.items.Add (newMeeting2);

            return newMeetings;
        }

        // ***************
        // private methods
        // ***************

        // returns a meeting
        private DTMeeting getMeeting(int index)
        {
            DTMeeting newMeeting = new DTMeeting();
            newMeeting.id = index;
            newMeeting.name = "Proteste ahora " + index + index;
            newMeeting.description = "Es hora de protestar. No hay que esperar";
            newMeeting.minQuorum = index * 6;
            return newMeeting;
        }
    }
}
