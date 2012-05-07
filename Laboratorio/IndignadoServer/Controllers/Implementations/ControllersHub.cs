using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    class ControllersHub
    {
        // *** singleton instances ***
        private static ControllersHub instance = null;
        private static IMeetingsController iMeetingsController;
        private static ISysAdminController iSysAdminController;
        private static IMovAdminController iMovAdminController;
        // ...

        private ControllersHub()
        {
        }

        // returns an instance of the IMeetingsController.
        public static ControllersHub getInstance()
        {
            if (instance == null)
            {
                instance = new ControllersHub();
                iMeetingsController = new MeetingsController();
                iSysAdminController = new SysAdminController();
                iMovAdminController = new MovAdminController();
            }
            return instance;
        }

        // returns an instance of the IMeetingsController.
        public IMeetingsController getIMeetingsController()
        {
            return iMeetingsController;
        }

        // returns an instance of the ISysAdminController.
        public ISysAdminController getISysAdminController()
        {
            return iSysAdminController;
        }

        // returns an instance of the IMovAdminController.
        public IMovAdminController getIMovAdminController()
        {
            return iMovAdminController;
        }

        /*
        // returns an instance of the IBlablaController.
        public static IBlablaController getIBlablaController();
         * */
    }
}
