using System.ServiceModel;

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

        // do assist to a meeting.
        [OperationContract]
        void doAssistMeeting(DTMeeting dtMeeting);

        // unconfirm assist to a meeting.
        [OperationContract]
        void unconfirmAssistMeeting(DTMeeting dtMeeting);

        // don't assist to a meeting.
        [OperationContract]
        void dontAssistMeeting(DTMeeting dtMeeting);
    }
}
