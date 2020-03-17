using masterLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masterLayout.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult loginPage()
        {
            return View();
        }

        public ActionResult search(loginValidation T)
        {
            if (ModelState.IsValid)
            {
                string user = Request.Form["username"];
                string pass = Request.Form["password"];
                bool msg = loginOps.search(user, pass);
                if (msg == true)
                    return View();
                else
                    return View("loginPage");
            }
            return View("loginPage");

        }
    }
}