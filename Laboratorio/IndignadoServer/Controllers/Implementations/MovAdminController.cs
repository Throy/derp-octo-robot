using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;

namespace IndignadoServer.Controllers
{
    class MovAdminController : IndignadoController, IMovAdminController
    {
        // ******************
        // controller methods
        // ******************

        // gets the admin's movement.
        public Movimiento getMovement()
        {
            // get movement from database
            Movimiento movement;
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            try
            {
                movement = indignadoContext.Movimientos.Single(x => x.id == IdMovement);
            }
            catch
            {
                movement = null;
            }
            return movement;
        }

        // changes the configuration of the movement.
        public void setMovement(Movimiento movement)
        {
            // *** lista de campos levantada de DTToClass.DTToMovement() ***

            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();
            movement.id = 0;
            indignadoContext.ExecuteCommand("UPDATE Movimiento SET nombre = {0}, descripcion = {1}, latitud = {2}, longitud = {3} WHERE id = {4}", movement.nombre, movement.descripcion, movement.latitud, movement.longitud, movement.id);
        }
    }
}
