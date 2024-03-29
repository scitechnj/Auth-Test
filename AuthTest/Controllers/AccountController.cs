﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthTest.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(returnUrl ?? "/");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Signup()
        {
            return View(new SignupViewModel());
        }

        [HttpPost]
        public ActionResult Signup(SignupViewModel viewModel)
        {
            try
            {
                var user = Membership.CreateUser(viewModel.Username, viewModel.Password);
                if (!Roles.RoleExists("Admin"))
                {
                    Roles.CreateRole("Admin");
                }
                Roles.AddUserToRole(viewModel.Username, "Admin");
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return View(new SignupViewModel { Username = viewModel.Username, ErrorMessage = ex.Message });
            }
        }

    }

    public class SignupViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}
