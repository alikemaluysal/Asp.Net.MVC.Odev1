using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deneme.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Elektronik()
        {
            return View();
        }

        public ActionResult Bilgisayar()
        {
            return View();
        }

        public ActionResult Telefon()
        {
            return View();
        }


    }
}