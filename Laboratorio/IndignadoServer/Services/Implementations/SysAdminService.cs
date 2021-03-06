﻿using System.Collections.ObjectModel;
using System.Security.Permissions;
using IndignadoServer.Controllers;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SysAdminService" in both code and config file together.
    public class SysAdminService : ISysAdminService
    {
        // creates a movement.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.SysAdmin)]
        public void createMovement (DTMovement dtMovement)
        {
            ControllersHub.Instance.getISysAdminController().createMovement(DTToClass.DTToMovement(dtMovement));
        }

        // returns all movements.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.SysAdmin)]
        public DTMovementsCol getMovementsList()
        {
            // create new meetings datatype collection
            DTMovementsCol dtMovementCol = new DTMovementsCol();
            dtMovementCol.items = new Collection<DTMovement>();

            // get meetings from the controller
            Collection<Movimiento> meetingsCol = ControllersHub.Instance.getISysAdminController().getMovementsList();

            // add meetings to the datatype collection
            foreach (Movimiento movement in meetingsCol)
            {
                dtMovementCol.items.Add (ClassToDT.MovementToDT(movement));
            }

            // return the collection
            return dtMovementCol;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Roles.SysAdmin)]
        public void enableMovement(int id) 
        {
            ControllersHub.Instance.getISysAdminController().enableMovement(id);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Roles.SysAdmin)]
        public void disableMovement(int id) 
        {
            ControllersHub.Instance.getISysAdminController().disableMovement(id);
        }
    }
}
