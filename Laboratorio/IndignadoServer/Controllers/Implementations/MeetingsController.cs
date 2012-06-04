using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    class MeetingsController : IndignadoController, IMeetingsController
    {
        // ********************
        // controller constants
        // ********************

        // maximum distance from a user that makes a meeting interesting, measured in km.
        const float maxDistanceInterest = 20.0F;

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
        public void createMeeting(Convocatoria meeting, Collection<CategoriasTematica> themeCategories)
        {
            // create meeting and add it to the database
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // set internal and foreign ids of the meeting.
            meeting.idMovimiento = IdMovement;
            meeting.idAutor = UserInfo.Id;

            // add the meeting to the database.
            indignadoContext.Convocatorias.InsertOnSubmit(meeting);
            indignadoContext.SubmitChanges();
            indignadoContext = new IndignadoDBDataContext();

            // remove current theme categories of the meeting.
            indignadoContext.ExecuteCommand("DELETE FROM CatTemasConvocatorias WHERE (idConvocatoria = {0})", meeting.id);

            // add all theme categories to the meeting.
            if (themeCategories != null)
            {
                foreach (CategoriasTematica themeCat in themeCategories)
                {
                    // create a themeCatMeeting
                    CatTemasConvocatoria themeCatMeeting = new CatTemasConvocatoria();
                    themeCatMeeting.idCategoriaTematica = themeCat.id;
                    themeCatMeeting.idConvocatoria = meeting.id;

                    // add the themeCatMeeting to the database.
                    indignadoContext.CatTemasConvocatorias.InsertOnSubmit(themeCatMeeting);
                }
            }

            // submit changes to the database.
            indignadoContext.SubmitChanges();
        }

        // returns all meetings
        public Collection<Convocatoria> getMeetingsList()
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Convocatoria> meetingsEnum = indignadoContext.ExecuteQuery<Convocatoria>
                ("SELECT id, idMovimiento, titulo, descripcion, longitud, latitud, minQuorum, logo, fechaInicio, fechaFin FROM Convocatorias WHERE idMovimiento = {0}", IdMovement);
            return toCollectionConvocatoria(meetingsEnum);
        }

        // returns all meetings that the user will attend or didn't confirm.
        public Collection<Convocatoria> getMeetingsListOnAttend()
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<Convocatoria> meetingsEnum = indignadoContext.ExecuteQuery<Convocatoria>
                ("SELECT Convocatorias.id, idMovimiento, titulo, descripcion, longitud, latitud, minQuorum, logo, fechaInicio, fechaFin FROM Convocatorias LEFT JOIN Asistencias ON (Asistencias.idConvocatoria = Convocatorias.id) WHERE idUsuario = {0}", UserInfo.Id);
            return toCollectionConvocatoria(meetingsEnum);
        }

        // returns all meetings that the user is interested in.
        public Collection<Convocatoria> getMeetingsListOnInterest()
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // get meetings by theme category.
            IEnumerable<Convocatoria> meetingsEnumByThemeCat = indignadoContext.ExecuteQuery<Convocatoria>
                ("SELECT Convocatorias.id, idMovimiento, titulo, descripcion, longitud, latitud, minQuorum, logo, fechaInicio, fechaFin FROM Convocatorias INNER JOIN (SELECT Convocatorias.id FROM Convocatorias LEFT JOIN CatTemasConvocatorias ON (CatTemasConvocatorias.idConvocatoria = Convocatorias.id) LEFT JOIN Intereses ON (Intereses.idCategoriaTematica = CatTemasConvocatorias.idCategoriaTematica) WHERE Intereses.idUsuario = {0} GROUP BY Convocatorias.id) ConvocatoriasInteres ON ConvocatoriasInteres.id = Convocatorias.id", UserInfo.Id);
            Collection<Convocatoria> meetingsCol = toCollectionConvocatoria(meetingsEnumByThemeCat);

            // add meetings by location
            IEnumerable<Convocatoria> meetingsEnumAll = indignadoContext.ExecuteQuery<Convocatoria>
                ("SELECT id, idMovimiento, titulo, descripcion, longitud, latitud, minQuorum, logo, fechaInicio, fechaFin FROM Convocatorias WHERE idMovimiento = {0}", IdMovement);

            // get the user's location
            float latiUserRadians = 0.0F;
            float longUserRadians = 0.0F;
            IEnumerable<Usuario> usuarios = indignadoContext.ExecuteQuery<Usuario>
                ("SELECT * FROM Usuarios WHERE (id = {0})", UserInfo.Id);
            foreach (Usuario usuario in usuarios)
            {
                latiUserRadians = (float) (usuario.latitud * Math.PI / 180);
                longUserRadians = (float) (usuario.longitud * Math.PI / 180);
            }

            foreach (Convocatoria meeting in meetingsEnumAll)
            {
                if (! meetingsCol.Any(m => m.id == meeting.id))
                {
                    // if the user is close to the meeting, add it.
                    float latiMeetingRadians = (float)(meeting.latitud * Math.PI / 180);
                    float longMeetingRadians = (float)(meeting.longitud * Math.PI / 180);
                    if (6378 * Math.Acos
                        (Math.Sin(latiUserRadians) * Math.Sin(latiMeetingRadians)
                        + Math.Cos(latiUserRadians) * Math.Cos(latiMeetingRadians) * Math.Cos(longUserRadians - longMeetingRadians)) < maxDistanceInterest)
                    {
                        // get number of attendants
                        IEnumerable<int> numbersAttendants = indignadoContext.ExecuteQuery<int>
                            ("SELECT COUNT(*) FROM Asistencias WHERE (idConvocatoria = {0}) AND (hayAsistencia = 1)", meeting.id);
                        foreach (int numberAttendants in numbersAttendants)
                        {
                            meeting.cantAsistencias = numberAttendants;
                        }

                        // get own attendance
                        meeting.miAsistencia = 0;
                        if (UserInfo != null)
                        {
                            IEnumerable<int> myAttendances = indignadoContext.ExecuteQuery<int>
                                ("SELECT hayAsistencia FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
                            foreach (int myAttendance in myAttendances)
                            {
                                meeting.miAsistencia = myAttendance;
                            }
                        }

                        // add item to the collection
                        meetingsCol.Add(meeting);
                    }
                }
            }

            // return the collection.
            return meetingsCol;
        }


        // convert meetings enumerables to collections.
        private Collection<Convocatoria> toCollectionConvocatoria(IEnumerable<Convocatoria> meetingsEnum)
        {
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            Collection<Convocatoria> meetingsCol = new Collection<Convocatoria>();
            foreach (Convocatoria meeting in meetingsEnum)
            {
                // get number of attendants
                IEnumerable<int> numbersAttendants = indignadoContext.ExecuteQuery<int>
                    ("SELECT COUNT(*) FROM Asistencias WHERE (idConvocatoria = {0}) AND (hayAsistencia = 1)", meeting.id);
                foreach (int numberAttendants in numbersAttendants)
                {
                    meeting.cantAsistencias = numberAttendants;
                }

                // get own attendance
                meeting.miAsistencia = 0;
                if (UserInfo != null)
                {
                    IEnumerable<int> myAttendances = indignadoContext.ExecuteQuery<int>
                        ("SELECT hayAsistencia FROM Asistencias WHERE (idConvocatoria = {0}) AND (idUsuario = {1})", meeting.id, UserInfo.Id);
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


        // returns all theme categories.
        public Collection<CategoriasTematica> getThemeCategoriesList()
        {
            // only get theme categories from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<CategoriasTematica> themeCategoriesEnum = indignadoContext.ExecuteQuery<CategoriasTematica>
                ("SELECT id, idMovimiento, titulo, descripcion FROM CategoriasTematicas WHERE idMovimiento = {0}", IdMovement);

            Collection<CategoriasTematica> themeCategoriesCol = new Collection<CategoriasTematica>();
            foreach (CategoriasTematica themeCategory in themeCategoriesEnum)
            {
                // add item to the collection
                themeCategoriesCol.Add(themeCategory);
            }

            // return the collection
            return themeCategoriesCol;
        }

        // returns all theme categories of a meeting.
        public Collection<CategoriasTematica> getThemeCategoriesMeeting(Convocatoria meeting)
        {
            // only get theme categories from this movement.
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            IEnumerable<CategoriasTematica> themeCategoriesEnum = indignadoContext.ExecuteQuery<CategoriasTematica>
                ("SELECT CategoriasTematicas.id, idMovimiento, titulo, descripcion FROM CategoriasTematicas LEFT JOIN CatTemasConvocatorias ON (CatTemasConvocatorias.idCategoriaTematica = CategoriasTematicas.id) WHERE (CatTemasConvocatorias.idConvocatoria = {0})", meeting.id);

            Collection<CategoriasTematica> themeCategoriesCol = new Collection<CategoriasTematica>();
            foreach (CategoriasTematica themeCategory in themeCategoriesEnum)
            {
                // add item to the collection
                themeCategoriesCol.Add(themeCategory);
            }

            // return the collection
            return themeCategoriesCol;
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
