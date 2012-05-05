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

        // private constructor
        private Persistence()
        {
            meetings = new Collection<Meeting>();
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

      
    }
}
