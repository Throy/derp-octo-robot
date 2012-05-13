using System.Collections.ObjectModel;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    interface IMeetingsController
    {
        // returns a meeting by its id.
        Convocatoria getMeeting(int idMeeting);

        // adds a meeting
        /*
        [OperationContract]
        void addEmptyMeeting();
         * */

        // creates a meeting
        void createMeeting(Convocatoria meeting);

        // returns all meetings
        Collection<Convocatoria> getMeetingsList();

        // do attend a meeting.
        void doAttendMeeting(Convocatoria meeting);

        // unconfirm attendance to a meeting.
        void unconfirmAttendanceMeeting(Convocatoria meeting);

        // don't atttend a meeting.
        void dontAttendMeeting(Convocatoria meeting);
    }
}
