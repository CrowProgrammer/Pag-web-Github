using System.Web;
using System.Web.Mvc;

namespace WebII_Lab05_Paco_Ramos_Aaron_Pedro_Ejercicio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
