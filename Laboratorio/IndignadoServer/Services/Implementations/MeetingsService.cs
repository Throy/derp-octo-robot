using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;
namespace IndignadoServer.Services
{
    // MeetingsService implements all the services of the Meetings subsystem.

    public class MeetingsService : IMeetingsService
    {
        // ***************
        // service methods
        // ***************


        // returns a meeting
        public DTMeeting getMeeting (int index)
        {
            // get meeting from database
            DTMeeting dataMeeting = new DTMeeting();
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            try
            {
                Convocatoria convocatoria = indignadoContext.Convocatorias.Single (x => x.id == index);
                dataMeeting = ClassToDT.MeetingToDT (convocatoria);
            }
            catch { 
                    dataMeeting = null;
            }
            return dataMeeting;
        }

        

        // creates a meeting
        public void createMeeting (DTMeeting dtMeeting)
        {
            // create meeting and add it to the database
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();

            // set internal and foreign ids (berreta)
            dtMeeting.id = indignadoContext.Convocatorias.Count();
            dtMeeting.idMovement = 666;

            indignadoContext.Convocatorias.InsertOnSubmit(DTToClass.MeetingToDT(dtMeeting));
            indignadoContext.SubmitChanges();
        }

        // returns all meetings
        public DTMeetingsCol getMeetingsList()
        {
            
            // create new meetings datatype collection
            DTMeetingsCol dtMeetingsCol = new DTMeetingsCol();
            dtMeetingsCol.items = new Collection<DTMeeting>();
            
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            
            // only get meetings from this movement.
            int idMovement = 666;
            foreach (Convocatoria meeting in indignadoContext.Convocatorias)
            {
                if (meeting.idMovimiento == idMovement)
                {
                    dtMeetingsCol.items.Add (ClassToDT.MeetingToDT (meeting));
                }
            }

            // return the collection
            return dtMeetingsCol;
        }
    }
}
