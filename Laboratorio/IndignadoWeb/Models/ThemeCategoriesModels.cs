using IndignadoWeb.MovAdminServiceReference;
using IndignadoWeb.UsersServiceReference;

namespace IndignadoWeb.Models
{
    public class ThemeCategoriesConfigModel
    {
        public DTThemeCategoriesColMovAdmin items { get; set; }

        public DTThemeCategoryMovAdmin newItem { get; set; }
    }

    public class ThemeCategoriesListModel
    {
        public DTThemeCategoriesColUsers items { get; set; }

        public DTThemeCategoryUsers newItem { get; set; }
    }
}
