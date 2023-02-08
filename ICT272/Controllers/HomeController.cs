using ICT272.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ICT272.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(User user)
            {
                if (ValidateUser(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("SecureMethod");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }

            public ActionResult AdminLogin()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AdminLogin(User user)
            {
                if (ValidateUser(user.UserName, user.Password) && CheckIfUserIsAdmin(user.UserName))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("AdminMethod");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }

            [Authorize(Roles = "Admin")]
            public ActionResult AdminMethod()
            {
                return View();
            }

            public ActionResult SecureMethod()
            {
                return View();
            }

            private bool ValidateUser(string username, string password)
            {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfUserIsAdmin(string UserName)
            {
            if (UserName == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        }

    }
