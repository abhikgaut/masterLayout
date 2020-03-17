using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masterLayout.Controllers
{
    public class bindingController : Controller
    {
        // GET: binding
        [ActionName("Example")]
        public ActionResult sample()
        {
            return View("sample");
        }
        public ActionResult update()
        {
            return View();
        }
    }
}