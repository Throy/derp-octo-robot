﻿using System.Collections.ObjectModel;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    interface IMeetingsController
    {
        // returns a meeting by its id.
        Convocatoria getMeeting(int idMeeting);

        // creates a meeting
        void createMeeting(Convocatoria meeting, Collection<CategoriasTematica> themeCategories);

        // returns all meetings
        Collection<Convocatoria> getMeetingsList();
        
        // returns all meetings that the user will attend or didn't confirm.
        Collection<Convocatoria> getMeetingsListOnAttend();
        
        // returns all meetings that the user is interested in.
        Collection<Convocatoria> getMeetingsListOnInterest();

        // returns all meetings that the user has been notified.
        Collection<Convocatoria> getMeetingsNotifications();
        
        // returns all theme categories.
        Collection<CategoriasTematica> getThemeCategoriesList();
        
        // returns all theme categories of a meeting.
        Collection<CategoriasTematica> getThemeCategoriesMeeting(Convocatoria meeting);

        // do attend a meeting.
        void doAttendMeeting(Convocatoria meeting);

        // unconfirm attendance to a meeting.
        void unconfirmAttendanceMeeting(Convocatoria meeting);

        // don't atttend a meeting.
        void dontAttendMeeting(Convocatoria meeting);
        
        // removes a meeting notification.
        void deleteMeetingNotification(Convocatoria meeting);
    }
}
