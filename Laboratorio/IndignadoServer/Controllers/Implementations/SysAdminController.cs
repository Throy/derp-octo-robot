using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    class SysAdminController : ISysAdminController
    {
        // ******************
        // controller methods
        // ******************

        // creates a movement.
        public void createMovement(Movimiento movement)
        {
            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();
            movement.id = indignadoContext.Movimientos.Count();
            indignadoContext.Movimientos.InsertOnSubmit (movement);
            indignadoContext.SubmitChanges();
        }

        // returns all movements
        public Collection<Movimiento> getMovementsList()
        {
            // create new movements datatype collection
            Collection<Movimiento> movementsCol = new Collection<Movimiento>();

            LinqDataContextDataContext indignadoContext = new LinqDataContextDataContext();

            foreach (Movimiento movement in indignadoContext.Movimientos)
            {
                movementsCol.Add(movement);
            }

            // return the collection
            return movementsCol;
        }

        public void enableMovement() { }

        public void disableMovement() { }
    }
}
