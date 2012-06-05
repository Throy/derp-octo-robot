using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;
using System;
using IndignadoServer.Services;
using System.Collections.Generic;

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
            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

            // creates the movement.
            movement.url.Replace(' ', '_');
            indignadoContext.Movimientos.InsertOnSubmit(movement);
            indignadoContext.SubmitChanges();

            // get the movement's id.
            IEnumerable<Movimiento> movementsEnum = indignadoContext.ExecuteQuery<Movimiento> ("SELECT id FROM Movimiento WHERE nombre = {0}", movement.nombre);

            int idMov = -1;
            foreach (Movimiento mov in movementsEnum)
            {
                if (mov.nombre == movement.nombre)
                {
                    idMov = mov.id;
                }
            }

            // creates the movement admin.
            DTRegisterModel user = new DTRegisterModel();
            user.nombre = "movadmin";
            user.apodo = "movadmin";
            user.contraseña = "1234";
            user.idMovimiento = idMov;
            user.latitud = (float)movement.latitud;
            user.longitud = (float)movement.longitud;
            user.mail = movement.nombre + "@tsi1.com.uy";
                
            Usuario userDb = DTToClass.DTToUsuario(user);
            userDb.banned = false;
            userDb.privilegio = (short) Roles.MovAdminMask;
            userDb.fechaRegistro = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, 0);
            indignadoContext.Usuarios.InsertOnSubmit(userDb);

            // submit changes to the database
            indignadoContext.SubmitChanges();
        }

        // returns all movements
        public Collection<Movimiento> getMovementsList()
        {
            // create new movements datatype collection
            Collection<Movimiento> movementsCol = new Collection<Movimiento>();

            IndignadoDBDataContext indignadoContext = new IndignadoDBDataContext();

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
