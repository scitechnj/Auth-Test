using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthTest.Controllers
{
    public class SecretController : Controller
    {
        [Authorize(Roles = "Regular,Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Regular,Admin")]
        public ActionResult RegularUser()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminUser()
        {
            return View();
        }

        [Authorize(Users = "Phil")]
        public ActionResult JustPhil()
        {
            return View();
        }

    }
}
