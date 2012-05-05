using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace IndignadoServer.Classes
{
    // persistence module

    public class Persistence
    {
        // singleton instance
        private static Persistence instance = null;

        // *********
        // atributes
        // *********

        private Collection<Meeting> meetings;

        private Collection<Movement> movements;

        // private constructor
        private Persistence()
        {
            meetings = new Collection<Meeting>();
            movements = new Collection<Movement>();
        }

        // public getter
        public static Persistence getInstance()
        {
            if (instance == null)
            {
                instance = new Persistence();
            }
            return instance;
        }

        // *******
        // methods
        // *******


        public Collection<Meeting> getMeetings() {
            return meetings;
        }

        public Collection<Movement> getMovements()
        {
            return movements;
        }


        // ***************
        // private methods
        // ***************

        // creates a new meeting
        /*
        public Meeting newMeeting (int index)
        {
            Meeting newMeeting = new Meeting();
            newMeeting.id = index;
            newMeeting.name = "Proteste ahora " + index + index;
            newMeeting.description = "Es hora de protestar. No hay que esperar";
            newMeeting.minQuorum = index * 6;
            return newMeeting;
        }
         * */
    }
}
