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

        // returns all meetings that the user will attend or didn't confirm.
        [OperationContract]
        DTMeetingsCol getMeetingsListOnAttend();

        // returns all meetings that the user is interested in.
        [OperationContract]
        DTMeetingsCol getMeetingsListOnInterest();
        
        // returns all theme categories.
        [OperationContract]
        DTThemeCategoriesColMeetings getThemeCategoriesList();

        // do attend a meeting.
        [OperationContract]
        void doAttendMeeting(DTMeeting dtMeeting);

        // unconfirm attendance to a meeting.
        [OperationContract]
        void unconfirmAttendMeeting(DTMeeting dtMeeting);

        // don't attend a meeting.
        [OperationContract]
        void dontAttendMeeting(DTMeeting dtMeeting);
    }
}
