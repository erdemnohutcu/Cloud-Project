using TravelAgency.Models;
using TravelAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class LoginController :Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            TravelaEntities db = new TravelaEntities();

            var usr = db.UserT.Where(u => u.username == model.username && u.userpassword == model.userpassword).FirstOrDefault();
            if (usr != null)
            {

                Session["username"] = usr.username.ToString();
                Session["userpassword"] = usr.userpassword.ToString();

                return Redirect("~/Home");
            }
            else
            {
                ModelState.AddModelError("err", "Please enter correct information");

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return Redirect("~/Login/Login");

        }
    }
}