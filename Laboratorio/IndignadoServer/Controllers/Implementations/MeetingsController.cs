using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;
using System.Collections.Generic;

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
            // only get meetings from this movement.
            int idMovement = 666;

            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            IEnumerable<Convocatoria> meetingsEnum = indignadoContext.ExecuteQuery<Convocatoria>("SELECT id, idMovimiento, titulo, descripcion, geoUbicacion, minQuorum FROM Convocatorias WHERE idMovimiento = {0}", idMovement);

            Collection<Convocatoria> meetingsCol = new Collection<Convocatoria>();
            foreach (Convocatoria meeting in meetingsEnum)
            {
                meetingsCol.Add (meeting);
            }

            // return the collection
            return meetingsCol;
        }
    }
}
