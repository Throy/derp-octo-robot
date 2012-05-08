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
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
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
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // set internal and foreign ids (berreta)
            meeting.id = indignadoContext.Convocatorias.Count();
            meeting.idMovimiento = 0;
            meeting.idAutor = 3;

            indignadoContext.Convocatorias.InsertOnSubmit(meeting);
            indignadoContext.SubmitChanges();
        }

        // returns all meetings
        public Collection<Convocatoria> getMeetingsList()
        {
            // only get meetings from this movement.
            int idMovement = 0;

            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Convocatoria> meetingsEnum = indignadoContext.ExecuteQuery<Convocatoria>("SELECT id, idMovimiento, titulo, descripcion, longitud, latitud, minQuorum FROM Convocatorias WHERE idMovimiento = {0}", idMovement);

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
