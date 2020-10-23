using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Context HomeContext = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BuildingDetails(String id)
        {
            Rent rent = HomeContext.Rents
                .SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

    }
}