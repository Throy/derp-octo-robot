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
            // get meetings collection
            DTMeeting dataMeeting = new DTMeeting();
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            try
            {
                Convocatoria convocatoria = indignadoContext.Convocatorias.Single(x => x.id == index);
                dataMeeting = ClassToDT.MeetingToDT(convocatoria);
            }
            catch { 
                    dataMeeting = null;
            }
            return dataMeeting;
        }

        

        // creates a meeting
        public void createMeeting (DTMeeting dtMeeting)
        {
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            dtMeeting.id = indignadoContext.Convocatorias.Count();
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
            
            foreach (Convocatoria meeting in indignadoContext.Convocatorias)
            {
                dtMeetingsCol.items.Add(ClassToDT.MeetingToDT(meeting));
            }

            // return the collection
            return dtMeetingsCol;
        }
    }
}
