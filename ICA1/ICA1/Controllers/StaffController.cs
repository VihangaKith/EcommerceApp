﻿using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private Context staffContext = new Context();
        public ActionResult Index()
        {
            List<Staff> AllStaff = staffContext.Staffs.ToList();
            return View(AllStaff);
        }
    }
}