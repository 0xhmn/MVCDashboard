using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Dahsboard.Models;

namespace MVC_Dahsboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CSOMContext();
            var programs = db.Programs.Select(p => p.ProgramTitle).ToList();

            return View(programs);
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
    }
}