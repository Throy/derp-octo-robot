using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    class MeetingsController : IMeetingsController
    {
        // ******************
        // controller methods
        // ******************

        // returns a meeting by its id.
        public Convocatoria getMeeting(int idMeeting)
        {
            // get meeting from database
            Convocatoria meeting;
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            try
            {
                meeting = indignadoContext.Convocatorias.Single(x => x.id == idMeeting);
            }
            catch
            {
                meeting = null;
            }
            return meeting;
        }



        // creates a meeting
        public void createMeeting(Convocatoria meeting)
        {
            // create meeting and add it to the database
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();

            // set internal and foreign ids (berreta)
            meeting.id = indignadoContext.Convocatorias.Count();
            meeting.idMovimiento = 666;

            indignadoContext.Convocatorias.InsertOnSubmit(meeting);
            indignadoContext.SubmitChanges();
        }

        // returns all meetings
        public Collection<Convocatoria> getMeetingsList()
        {
            // create new meetings collection
            Collection<Convocatoria> meetingsCol = new Collection<Convocatoria>();

            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();

            // only get meetings from this movement.
            int idMovement = 666;
            foreach (Convocatoria meeting in indignadoContext.Convocatorias)
            {
                if (meeting.idMovimiento == idMovement)
                {
                    meetingsCol.Add(meeting);
                }
            }

            // return the collection
            return meetingsCol;
        }
    }
}
