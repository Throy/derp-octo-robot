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
        
        // do assist to a meeting.
        void doAssistMeeting(Convocatoria meeting);

        // unconfirm assist to a meeting.
        void unconfirmAssistMeeting(Convocatoria meeting);

        // don't assist to a meeting.
        void dontAssistMeeting(Convocatoria meeting);
    }
}
