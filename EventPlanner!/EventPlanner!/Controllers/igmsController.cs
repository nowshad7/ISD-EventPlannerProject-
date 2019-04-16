using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventPlanner_;
using System.Web;

namespace EventPlanner_.Controllers
{
    public class igmsController : Controller
    {
        private galleryEntities1 db = new galleryEntities1();

        // GET: igms
        public ActionResult Index()
        {
            return View(db.igms.ToList());
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
