using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    interface ISysAdminController
    {
        // creates a movement.
        void createMovement(Movimiento movement);

        // returns all movements
        Collection<Movimiento> getMovementsList();

        void enableMovement();

        void disableMovement();
    }
}
