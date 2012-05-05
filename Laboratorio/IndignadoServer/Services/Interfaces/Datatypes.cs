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

    // Meeting COllection datatype
    [DataContract]
    public class DTMeetingsCol
    {
        [DataMember]
        public Collection<DTMeeting> items { get; set; }
    }

    // **********
    // conversors
    // **********
    
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
    }

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
    }

}
