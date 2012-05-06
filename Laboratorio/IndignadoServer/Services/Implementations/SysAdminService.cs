using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SysAdminService" in both code and config file together.
    public class SysAdminService : ISysAdminService
    {

        
        public void createMovement (DTMovement dtMovement)
        {
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            Movimiento nuevo = DTToClass.DTToMovement(dtMovement);
            nuevo.id = indignadoContext.Movimientos.Count();
            indignadoContext.Movimientos.InsertOnSubmit(nuevo);
            indignadoContext.SubmitChanges();
        }

        public void setMovement(){}


        // returns all movements
        public DTMovementsCol getMovementsList()
        {
            // create new movements datatype collection
            DTMovementsCol dtMovementsCol = new DTMovementsCol();
            dtMovementsCol.items = new Collection<DTMovement>();

            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();

            foreach (Movimiento movement in indignadoContext.Movimientos)
            {
                dtMovementsCol.items.Add (ClassToDT.MovementToDT(movement));
            }

            // return the collection
            return dtMovementsCol;
        }

        public void enableMovement(){}
        
        public void disableMovement(){}
    }
}
