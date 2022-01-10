using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excel_On_Services.Models;

namespace Excel_On_Services.Controllers
{
    public class EmployeesController : Controller
    {
        private Entities db = new Entities();

        //// GET: Employees
        //public ActionResult Index()
        //{
        //    var employees = db.Employees.Include(e => e.Department);
        //    return View(employees.ToList());
        //}

        //[HttpPost]
        public ActionResult Index(Employee E, string searchBy, string search )
        {
            if (searchBy == null)
            {
                return View(db.Employees.ToList());
            }
            else if (searchBy == "Emp_Gender" && search != null)
            {
                return View(db.Employees.Where(x => x.Emp_Gender == search).ToList());
            }
            else if (searchBy == "Emp_Name" && search != null)
            {
                return View(db.Employees.Where(x => x.Emp_Name.Contains(search)).ToList());
            }
            else if (searchBy == "Type_Of_Service" && search != null)
            {
                return View(db.Employees.Where(x => x.Type_Of_Service.Contains(search)).ToList());
            }
            else if (searchBy == "Department.Dept_name" && search != null)
            {
                Department a = db.Departments.Where(x => x.Dept_name.Equals(search)).FirstOrDefault();
                var dept = a.Dept_Id;
                return View(db.Employees.Where(x => x.dept_id == dept).ToList());
            }
            else
            {
                return Content("Data not matched");
            }
            return View();
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
            ViewBag.dept_id = new SelectList(db.Departments, "Dept_Id", "Dept_name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_Id,dept_id,Emp_Name,Emp_Email,Emp_Contact,Emp_Address,Emp_Gender,Emp_Salary,Type_Of_Service,Emp_Images")] Employee employee, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                 string filename = file.FileName;
                    string location = "~/images/" + filename;
                    file.SaveAs(Server.MapPath(location));
                    employee.Emp_Images = location;

                    db.Employees.Add(employee);
                    db.SaveChanges();
                    
                
               
                return RedirectToAction("Index");
            }

            ViewBag.dept_id = new SelectList(db.Departments, "Dept_Id", "Dept_name", employee.dept_id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.dept_id = new SelectList(db.Departments, "Dept_Id", "Dept_name", employee.dept_id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_Id,dept_id,Emp_Name,Emp_Email,Emp_Contact,Emp_Address,Emp_Gender,Emp_Salary,Type_Of_Service,Emp_Images")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dept_id = new SelectList(db.Departments, "Dept_Id", "Dept_name", employee.dept_id);
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
