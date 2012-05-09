using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignadoServer
{
    static class Roles
    {
        public const String RegUser = "RegisteredUser";
        public const String MovAdmin = "MovementAdministrator";
        public const String SysAdmin = "SystemAdministrator";

        public const UInt32 MovAdminMask = 2;
        public const UInt32 SysAdminMask = 4;
    }
}
