using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudProjectData.Model;
using CrudProjectData.Services;

namespace CrudProject.Controllers
{
    public class EmployeesController : Controller
    {
        private EmpDataContext db = new EmpDataContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult loaddata()
        {
            using (EmpDataContext db = new EmpDataContext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var data = db.Employees.ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Branch = getBranches();

            ViewBag.Department = getDepartments();

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Emp_no,Branch,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Branch = getBranches();

            ViewBag.Department = getDepartments();

            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Emp_no,Branch,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [NonAction]
        public List<SelectListItem> getDepartments()
        {
            List<SelectListItem> Departments = new List<SelectListItem>() {
                 new SelectListItem{ Value="It",Text="It"},
                 new SelectListItem{ Value="Accounts",Text="Accounts"},
                 new SelectListItem{ Value="HR",Text="HR"},
                 new SelectListItem{ Value="Sales",Text="Sales"},
                 new SelectListItem{ Value="Purchase",Text="Purchase"},
                 new SelectListItem{ Value="Admin",Text="Admin"},
            };

            return Departments;
        }

        [NonAction]
        public List<SelectListItem> getBranches()
        {
            List<SelectListItem> Branches = new List<SelectListItem>() {
                 new SelectListItem{ Value="Delhi",Text="Delhi"},
                 new SelectListItem{ Value="Pune",Text="Pune"},
                 new SelectListItem{ Value="Hyderabad",Text="Hyderabad"},
                 new SelectListItem{ Value="Bangalore",Text="Bangalore"},
                 new SelectListItem{ Value="Chennai",Text="Chennai"},
                 new SelectListItem{ Value="Mumbai",Text="Mumbai"},
            };

            return Branches;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
