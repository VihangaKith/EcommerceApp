using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        private Context branchContext = new Context();
        public ActionResult Index()
        {
            List<Branch> AllBranches = branchContext.Branches.ToList();
            return View(AllBranches);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            branchContext.Branches.Add(branch);
            branchContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String Id)
        {
            Branch branch = branchContext.Branches.SingleOrDefault(x=>x.BranchNo==Id);
            return View(branch);
        }
        public ActionResult Edit(String Id)
        {
            Branch branch = branchContext.Branches.SingleOrDefault(x => x.BranchNo == Id);
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(String Id,Branch updatedBranch)
        {
            Branch branch = branchContext.Branches.SingleOrDefault(x => x.BranchNo == Id);
            branch.BranchNo = updatedBranch.BranchNo;
            branch.Street = updatedBranch.Street;
            branch.City = updatedBranch.City;
            branch.PostCode = updatedBranch.PostCode;
            branchContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String Id)
        {
            Branch branch = branchContext.Branches.SingleOrDefault(x => x.BranchNo == Id);
            return View(branch);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteBranch(String Id)
        {
            Branch branch = branchContext.Branches.SingleOrDefault(x => x.BranchNo == Id);
            branchContext.Branches.Remove(branch);
            branchContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}