using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCineAPP.Controllers
{
    public class CinesController : Controller
    {
        // GET: Cines
        public ActionResult Index()
        {
            return View();
        }
    }
}