using System.Web;
using System.Web.Mvc;

namespace Coding_Challenge_9_Question_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
