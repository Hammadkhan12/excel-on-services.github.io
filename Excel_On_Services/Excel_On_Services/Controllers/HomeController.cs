using Excel_On_Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Excel_On_Services.Controllers
{
    public class HomeController : Controller
    { 
        Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact(Contact ct)
        {
            try
            {
                db.Contacts.Add(ct);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return Content("<script> alert('Your form has been submitted') </script>");
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return View();
        }

        public ActionResult Service()
        {

            return View();
        }

        public ActionResult Management()
        {
            return View();
        }

    }
}
