using System.Web;
using System.Web.Mvc;

namespace mbs.cardlandia.userprofile.webapi {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
