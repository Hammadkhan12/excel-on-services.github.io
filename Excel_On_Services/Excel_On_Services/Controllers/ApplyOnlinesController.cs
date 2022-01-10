using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excel_On_Services.Models;
using System.IO;

namespace Excel_On_Services.Controllers
{
    public class ApplyOnlinesController : Controller
    {
        private Entities db = new Entities();

        // GET: ApplyOnlines
        public ActionResult Index()
        {
            return View(db.ApplyOnlines.ToList());
        }

        // GET: ApplyOnlines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplyOnline applyOnline = db.ApplyOnlines.Find(id);
            if (applyOnline == null)
            {
                return HttpNotFound();
            }
            return View(applyOnline);
        }

        // GET: ApplyOnlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplyOnlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplyOnline ap, HttpPostedFileBase file)
        {
            //if(file == null)
            //{
            //    ModelState.AddModelError("Customerror", "Please Select CV");
            //    return View();
            //}
            //if (!(file.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" ||
            //    file.ContentType == "application/pdf"))
            //{
            //    ModelState.AddModelError("Customerror", "Only .docx and .pdf file allowed");
            //    return View();
            //}
            if (ModelState.IsValid)
            {
               
                    string filename = file.FileName;
                    string location = "~/CV/" + filename;
                    file.SaveAs(Server.MapPath(location));
                    ap.CV = location;

                    db.ApplyOnlines.Add(ap);
                    db.SaveChanges();
                   // string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                   // file.SaveAs(Path.Combine(Server.MapPath("~/CVUpload"), fileName));
                   // {
                   //     ap.CV = fileName;
                   //     db.ApplyOnlines.Add(ap);
                   //     db.SaveChanges();
                   // }
                   // ModelState.Clear();
                   // ap = null;
                   // ViewBag.Message = "Form Is Successfully Submitted, Our Representatives Will Contact You Soon";
                   ///* return RedirectToAction("Index");*/
             
            }

            return View();
        }

        // GET: ApplyOnlines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplyOnline applyOnline = db.ApplyOnlines.Find(id);
            if (applyOnline == null)
            {
                return HttpNotFound();
            }
            return View(applyOnline);
        }

        // POST: ApplyOnlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "First_Name,Last_Name,Father_Name,N_I_C,Gender,Qualification,Result,Date_Of_Birth,City,Country,Contact,Address,Email")] ApplyOnline applyOnline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applyOnline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applyOnline);
        }

        // GET: ApplyOnlines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplyOnline applyOnline = db.ApplyOnlines.Find(id);
            if (applyOnline == null)
            {
                return HttpNotFound();
            }
            return View(applyOnline);
        }

        // POST: ApplyOnlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplyOnline applyOnline = db.ApplyOnlines.Find(id);
            db.ApplyOnlines.Remove(applyOnline);
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
