using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.Classes;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SysAdminService" in both code and config file together.
    public class SysAdminService : ISysAdminService
    {

        // creates a movement
        public void createMovement (DTMovement dtMovement)
        {
            // get movements collection
            Collection<Movement> movementsCol = Persistence.getInstance().getMovements();

            // set new id (berreta)
            dtMovement.id = Persistence.getInstance().getMovements().Count;

            // add the new movement to the collection
            movementsCol.Add (DTToClass.MovementToDT (dtMovement));
        }

        public void setMovement(){}


        // returns all movements
        public DTMovementsCol getMovementsList()
        {
            // get movements collection
            Collection<Movement> movementsCol = Persistence.getInstance().getMovements();

            // create new movements datatype collection
            DTMovementsCol dtMovementsCol = new DTMovementsCol();

            // add movements datatypes to the collection
            dtMovementsCol.items = new Collection<DTMovement>();
            foreach (Movement movement in movementsCol)
            {
                dtMovementsCol.items.Add (ClassToDT.MovementToDT (movement));
            }

            // return the collection
            return dtMovementsCol;
        }

        public void enableMovement(){}
        
        public void disableMovement(){}
    }
}
