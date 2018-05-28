using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Login
{

    public class BaseController : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            bool isControler = controllerName == "Web" && actionName == "Index";

            if (!isControler)
            {
                if (Session["username"] == null && Session["userpassword"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Login/Login");
                    return;
                }
            }

            else

                base.OnActionExecuting(filterContext);
        }
    }
}
