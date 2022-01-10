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
    public class ClientsController : Controller
    {
        private Entities db = new Entities();

        // GET: Clients
        public ActionResult Index(Client C, string searchBy, string search)
        {
            if (searchBy == null)
            {
                return View(db.Clients.ToList());
            }
            else if (searchBy == "Name" && search != null)
            {
                return View(db.Clients.Where(x => x.Name.Contains(search)).ToList());
            }
            else if (searchBy == "Email" && search != null)
            {
                return View(db.Clients.Where(x => x.Email.Contains(search)).ToList());
            }
            else if (searchBy == "Service" && search != null)
            {
                return View(db.Clients.Where(x => x.Service.Contains(search)).ToList());
            }
            else if (searchBy == "Plan" && search != null)
            {
                return View(db.Clients.Where(x => x.Plan.Contains(search)).ToList());
            }
            else
            {
                return Content("Data not matched");
            }
            return View();
            // return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Contact,Address,Service,Plan")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return Content("<script> alert('Your form has been submitted') </script>");
                }
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Contact,Address,Service,Plan")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
