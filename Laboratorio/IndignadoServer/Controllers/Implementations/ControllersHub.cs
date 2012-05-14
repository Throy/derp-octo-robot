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
        private static ControllersHub _instance = null;
        private static ISessionController  _iSessionController;
        private static IMeetingsController _iMeetingsController;
        private static ISysAdminController _iSysAdminController;
        private static IMovAdminController _iMovAdminController;
        private static INewsResourcesController _iNewsResourcesController;
        private static IUsersController _iUsersController;
        // ...

        private ControllersHub()
        {
        }

        // returns an instance of the IMeetingsController.
        public static ControllersHub Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ControllersHub();
                    _iSessionController = new SessionController();
                    _iMeetingsController = new MeetingsController();
                    _iSysAdminController = new SysAdminController();
                    _iMovAdminController = new MovAdminController();
                    _iNewsResourcesController = new NewsResourcesController();
                    _iUsersController = new UsersController();
                }
                return _instance;
            }
        }

        // returns an instance of the ISessionController.
        public ISessionController getISessionController()
        {
            return _iSessionController;
        }

        // returns an instance of the IMeetingsController.
        public IMeetingsController getIMeetingsController()
        {
            return _iMeetingsController;
        }

        // returns an instance of the ISysAdminController.
        public ISysAdminController getISysAdminController()
        {
            return _iSysAdminController;
        }

        // returns an instance of the IMovAdminController.
        public IMovAdminController getIMovAdminController()
        {
            return _iMovAdminController;
        }

        // returns an instance of the INewsResourcesController.
        public INewsResourcesController getINewsResourcesController()
        {
            return _iNewsResourcesController;
        }


        // returns an instance of the IUsersController.
        public IUsersController getIUsersController()
        {
            return _iUsersController;
        }

        /*
        // returns an instance of the IBlablaController.
        public IBlablaController getIBlablaController()
        {
            return _iBlablaController;
        }
         * */
    }
}
