using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IndignadoServer
{
    class UserOnlineInfo
    {
        private int _id;
        private int _idMovimiento;
        private String _apodo;
        private String _token;
        private String[] _roles;

        public int Id { get { return _id; } set { _id = value; } }
        public int IdMovimiento { get { return _idMovimiento; } set { _idMovimiento = value; } }
        public String Apodo { get { return _apodo; } set { _apodo = value; } }
        public String Token { get { return _token; } set { _token = value; } }
        public String[] Roles { get { return _roles; } set { _roles = value; } }

        public UserOnlineInfo(int id, String apodo, int privilegios, int idMovimiento, String token)
        {
            _id = id;
            _apodo = apodo;
            _token = token;
            _idMovimiento = idMovimiento;

            ArrayList list = new ArrayList();
            list.Add(IndignadoServer.Roles.RegUser);
            if ((privilegios & IndignadoServer.Roles.MovAdminMask) != 0)
                list.Add(IndignadoServer.Roles.MovAdmin);
            if ((privilegios & IndignadoServer.Roles.SysAdminMask) != 0)
                list.Add(IndignadoServer.Roles.SysAdmin);

            _roles = list.ToArray(typeof(string)) as string[];
        }
    }
}
