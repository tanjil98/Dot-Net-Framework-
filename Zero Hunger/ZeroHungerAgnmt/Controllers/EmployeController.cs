using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAgnmt.Database;
using ZeroHungerAgnmt.Models;

namespace ZeroHungerAgnmt.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
       
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var DBcontext = new Zero_HungerEntities2 { };
            var data2 = DBcontext.Parsels.Where(Parsel => Parsel.Employee == userId).ToList();

            /*var allRequest = DBcontext.Parsels.ToList();*/
            return View(data2);
        }
        [HttpPost]
        public ActionResult Index(StatusDTO assign)
        {
            var DBcontext = new Zero_HungerEntities2 { };
            var ParselID = DBcontext.Parsels.Find(assign.Id);
            if (ParselID != null)
            {
                ParselID.Status = assign.Status;
                DBcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}