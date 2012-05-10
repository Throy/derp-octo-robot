using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface IMovAdminController
    {
        // gets the admin's movement.
        Movimiento getMovement();

        // changes the configuration of the movement.
        void setMovement(Movimiento dtMovement);

        void addRssSource(String url, String tag);
        void removeRssSource(String url, String tag);
        DTRssSourcesCol listRssSources(); 
    }
}
