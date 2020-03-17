using masterLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace masterLayout.Controllers
{
    public class EmpController : Controller
    {
        static List<EMPDATA> list = null;
        // GET: Emp
        public ActionResult Index()
        {
            List<EMPDATA> L = OOPS.getall();
            return View(L);
        }
        public ActionResult create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult create(EMPDATA E)
        {
            ViewBag.msg = OOPS.insertEmp(E);
            return View("Index", OOPS.getall());
        }
        public ActionResult edit(int id)
        {
            return View(OOPS.GetEmpupdate(id));
        }
        [HttpPost]
        public ActionResult edit(EMPDATA E)
        {
            OOPS.updateEmp(E);
            return View();
        }
        //to change particular value , in place of include use exclude 
        //[HttpPost]
        //public ActionResult edit([Bind(Include="ENAME,JOB")]EMPDATA E)
        //{
        //    return View();
        //}
        public ActionResult delete(int id)
        {
            OOPS.delEmp(id);
            return View("Index", OOPS.getall());
        }
        public ActionResult chkboxEmp()
        {
            var emp = Request.Form.Get("cid");
            list = OOPS.getall();
            List<EMPDATA> nlist = new List<EMPDATA>();
            foreach (var e in list)
            {
                if (emp.Contains(e.EMPNO.ToString()))
                {
                    nlist.Add(e);
                }
            }
            return View(nlist);
        }
    }
}