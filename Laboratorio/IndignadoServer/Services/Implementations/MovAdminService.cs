using System.Security.Permissions;
using IndignadoServer.Controllers;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovAdmin" in both code and config file together.
    public class MovAdminService : IMovAdminService
    {
        // gets the admin's movement.
        public DTMovement getMovement()
        {
            try
            {
                return ClassToDT.MovementToDT(ControllersHub.Instance.getIMovAdminController().getMovement());
            }
            catch
            {
                return null;
            }
        }

        // changes the configuration of the movement.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void setMovement(DTMovement dtMovement)
        {
            ControllersHub.Instance.getIMovAdminController().setMovement(DTToClass.DTToMovement(dtMovement));
        }


        public void addRssSource(DTRssSource dtRssSource){
            ControllersHub.Instance.getIMovAdminController().addRssSource(dtRssSource.url,dtRssSource.tag);
        }


        public void removeRssSource(DTRssSource dtRssSource){
            ControllersHub.Instance.getIMovAdminController().removeRssSource(dtRssSource.url,dtRssSource.tag);
        }

        public DTRssSourcesCol listRssSources(){
            return ControllersHub.Instance.getIMovAdminController().listRssSources();
        }
    }
}
