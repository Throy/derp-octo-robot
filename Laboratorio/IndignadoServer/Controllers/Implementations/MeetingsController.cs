using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    class MeetingsController : IndignadoController, IMeetingsController
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

            // set internal and foreign ids 
            meeting.idMovimiento = IdMovement;
            meeting.idAutor = UserInfo.Id;

            indignadoContext.Convocatorias.InsertOnSubmit(meeting);
            indignadoContext.SubmitChanges();
        }

        // returns all meetings
        public Collection<Convocatoria> getMeetingsList()
        {
            // only get meetings from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Convocatoria> meetingsEnum = indignadoContext.ExecuteQuery<Convocatoria>("SELECT id, idMovimiento, titulo, descripcion, longitud, latitud, minQuorum FROM Convocatorias WHERE idMovimiento = {0}", IdMovement);

            Collection<Convocatoria> meetingsCol = new Collection<Convocatoria>();
            foreach (Convocatoria meeting in meetingsEnum)
            {
                // get number of assists
                IEnumerable<int> numbersAssists = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Asistencias WHERE (idConvocatoria = {0}) AND (hayAsistencia = 1)", meeting.id);
                foreach (int numberAssists in numbersAssists)
                {
                    meeting.cantAsistencias = numberAssists;
                }

                // get own assist
                meeting.miAsistencia = 0;
                if (UserInfo != null)
                {
                    IEnumerable<int> myAssists = indignadoContext.ExecuteQuery<int>("SELECT hayAsistencia FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                    foreach (int myAssist in myAssists)
                    {
                        meeting.miAsistencia = myAssist;
                    }
                }
            
                // add item to the collection
                meetingsCol.Add(meeting);
            }

            // return the collection
            return meetingsCol;
        }

        // do assist to a meeting.
        public void doAssistMeeting(Convocatoria meeting)
        {
            // create an assist
            Asistencia assist = new Asistencia();
            assist.idConvocatoria = meeting.id;
            assist.idUsuario = UserInfo.Id;
            assist.hayAsistencia = 1;

            // add likeResource to the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                indignadoContext.Asistencias.InsertOnSubmit(assist);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }

        // unconfirm assist to a meeting.
        public void unconfirmAssistMeeting(Convocatoria meeting)
        {
            // create an assist
            Asistencia assist = new Asistencia();
            assist.idConvocatoria = meeting.id;
            assist.idUsuario = UserInfo.Id;
            assist.hayAsistencia = -1;

            // add likeResource to the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                indignadoContext.Asistencias.InsertOnSubmit(assist);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }

        // don't assist to a meeting.
        public void dontAssistMeeting(Convocatoria meeting)
        {
            // remove likeResource from the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }
    }
}
