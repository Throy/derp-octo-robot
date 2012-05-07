﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.Controllers;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovAdmin" in both code and config file together.
    public class MovAdminService : IMovAdminService
    {
        // gets a movement by its id.
        public DTMovement getMovement(int idMovement)
        {
            try
            {
                return ClassToDT.MovementToDT(ControllersHub.getInstance().getIMovAdminController().getMovement(idMovement));
            }
            catch
            {
                return null;
            }
        }

        // changes the configuration of the movement.
        public void setMovement(DTMovement dtMovement)
        {
            ControllersHub.getInstance().getIMovAdminController().setMovement(DTToClass.DTToMovement(dtMovement));
        }
    }
}
