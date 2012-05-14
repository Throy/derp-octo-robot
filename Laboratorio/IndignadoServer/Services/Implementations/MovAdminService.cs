using System.Collections.ObjectModel;
using System.Security.Permissions;
using IndignadoServer.Controllers;
using IndignadoServer.LinqDataContext;

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

        // adds a new rss resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void addRssSource(DTRssSource dtRssSource){
            ControllersHub.Instance.getIMovAdminController().addRssSource(dtRssSource.url,dtRssSource.tag);
        }

        // removes a current rss resource.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void removeRssSource(DTRssSource dtRssSource){
            ControllersHub.Instance.getIMovAdminController().removeRssSource(dtRssSource.url,dtRssSource.tag);
        }

        // gets the rss resources.
        public DTRssSourcesCol listRssSources(){
            return ControllersHub.Instance.getIMovAdminController().listRssSources();
        }
        
        // adds a new theme category.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void addThemeCategory(DTThemeCategoryMovAdmin dtThemeCategory)
        {
            ControllersHub.Instance.getIMovAdminController().addThemeCategory(DTToClass.DTToThemeCategoryMovAdmin(dtThemeCategory));
        }
        
        // removes a current theme category.
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.MovAdmin)]
        public void removeThemeCategory(DTThemeCategoryMovAdmin dtThemeCategory)
        {
            ControllersHub.Instance.getIMovAdminController().removeThemeCategory(DTToClass.DTToThemeCategoryMovAdmin(dtThemeCategory));
        }
        
        // gets the theme categories.
        public DTThemeCategoriesColMovAdmin listThemeCategories()
        {
            // create new theme categories datatype collection
            DTThemeCategoriesColMovAdmin dtThemeCategoriesCol = new DTThemeCategoriesColMovAdmin();
            dtThemeCategoriesCol.items = new Collection<DTThemeCategoryMovAdmin>();

            // get theme categories from the controller
            Collection<CategoriasTematica> themeCategoriesCol = ControllersHub.Instance.getIMovAdminController().listThemeCategories();

            // add theme categories to the datatype collection
            foreach (CategoriasTematica themeCategory in themeCategoriesCol)
            {
                dtThemeCategoriesCol.items.Add(ClassToDT.ThemeCategoryMovAdminToDT(themeCategory));
            }

            // return the collection
            return dtThemeCategoriesCol;
        }
    }
}
