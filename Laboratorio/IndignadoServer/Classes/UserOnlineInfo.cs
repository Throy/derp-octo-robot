using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignadoServer
{
    class UserOnlineInfo
    {
        private int _id;
        private int _idMovimiento;
        private String _token;

        public int Id { get { return _id; } set { _id = value; } }
        public int IdMovimiento { get { return _idMovimiento; } set { _idMovimiento = value; } }
        public String Token { get { return _token; } set { _token = value; } }

        public UserOnlineInfo(int id, int idMovimiento, String token)
        {
            _id = id;
            _token = token;
            _idMovimiento = idMovimiento;
        }
    }
}
