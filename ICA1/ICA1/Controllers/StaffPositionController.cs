using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class StaffPositionController : Controller
    {
        // GET: StaffPosition
        private Context staffContext = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StaffByPosition(String id)
        {
            List<Staff> staff = staffContext.Staffs.Where(x => x.StaffNo == id).ToList();
            return View(staff);
        }

        
    }
}