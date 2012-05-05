using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer.Services
{
    // IMeetingsService defines all the services of the Meetings subsystem.

    [ServiceContract]
    public interface IMeetingsService
    {
        // returns a meeting
        /*
        [OperationContract]
        DTMeeting getMeeting();
         * */

        // returns a meeting
        [OperationContract]
        DTMeeting getMeeting (int index);

        // adds a meeting
        /*
        [OperationContract]
        void addEmptyMeeting();
         * */

        // creates a meeting
        [OperationContract]
        void createMeeting (DTMeeting dtMeeting);

        // returns all meetings
        [OperationContract]
        DTMeetingsCol getMeetingsList();
    }
}
