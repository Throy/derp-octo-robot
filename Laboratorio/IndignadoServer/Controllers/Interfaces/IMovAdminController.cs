using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    interface IMovAdminController
    {
        // gets a movement by its id.
        Movimiento getMovement(int idMovement);

        // changes the configuration of the movement.
        void setMovement(Movimiento dtMovement);
    }
}
