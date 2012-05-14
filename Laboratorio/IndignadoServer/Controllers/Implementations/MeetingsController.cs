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
                // get number of attendants
                IEnumerable<int> numbersAttendants = indignadoContext.ExecuteQuery<int>("SELECT COUNT(*) FROM Asistencias WHERE (idConvocatoria = {0}) AND (hayAsistencia = 1)", meeting.id);
                foreach (int numberAttendants in numbersAttendants)
                {
                    meeting.cantAsistencias = numberAttendants;
                }

                // get own attendance
                meeting.miAsistencia = 0;
                if (UserInfo != null)
                {
                    IEnumerable<int> myAttendances = indignadoContext.ExecuteQuery<int>("SELECT hayAsistencia FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                    foreach (int myAttendance in myAttendances)
                    {
                        meeting.miAsistencia = myAttendance;
                    }
                }
            
                // add item to the collection
                meetingsCol.Add(meeting);
            }

            // return the collection
            return meetingsCol;
        }

        // do attend a meeting.
        public void doAttendMeeting(Convocatoria meeting)
        {
            // create an attendance
            Asistencia attendance = new Asistencia();
            attendance.idConvocatoria = meeting.id;
            attendance.idUsuario = UserInfo.Id;
            attendance.hayAsistencia = 1;

            // add likeResource to the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                indignadoContext.Asistencias.InsertOnSubmit(attendance);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }

        // unconfirm attendance to a meeting.
        public void unconfirmAttendanceMeeting(Convocatoria meeting)
        {
            // create an attendance
            Asistencia attendance = new Asistencia();
            attendance.idConvocatoria = meeting.id;
            attendance.idUsuario = UserInfo.Id;
            attendance.hayAsistencia = -1;

            // add likeResource to the database.
            try
            {
                IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
                indignadoContext.ExecuteCommand("DELETE FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                indignadoContext.Asistencias.InsertOnSubmit(attendance);
                indignadoContext.SubmitChanges();
            }
            catch (Exception error)
            {
            }
        }

        // don't attend a meeting.
        public void dontAttendMeeting(Convocatoria meeting)
        {
            // remove attendance from the database.
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
