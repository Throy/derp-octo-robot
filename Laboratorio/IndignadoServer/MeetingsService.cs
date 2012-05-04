using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MeetingsService : IMeetingsService
    {
        // returns a meeting
        public DTMeeting getMeeting()
        {
            DTMeeting newMeeting = new DTMeeting();
            newMeeting.id = 1;
            newMeeting.name = "Proteste ahora";
            newMeeting.description = "Es hora de protestar. No hay que esperar";
            newMeeting.minQuorum = 6;
            return newMeeting;
        }
    }
}
