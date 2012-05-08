﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Security.Cryptography;
using IndignadoServer.Controllers;

namespace IndignadoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SessionService" in both code and config file together.
    public class SessionService : ISessionService
    {
        public String Login(int idMovmiento, String userName, String password)
        {
            return SessionController.Instance.Login(idMovmiento, userName, password);
        }
    }
}