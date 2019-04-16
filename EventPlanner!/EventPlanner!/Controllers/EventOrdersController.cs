using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventPlanner_;

namespace EventPlanner_.Controllers
{
	[Authorize]
    public class EventOrdersController : Controller
    {
        private EventPlannerEntities db = new EventPlannerEntities();

        // GET: EventOrders
        public ActionResult Index()
        {
            return View(db.EventOrder.ToList());
        }

        // GET: EventOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOrder eventOrder = db.EventOrder.Find(id);
            if (eventOrder == null)
            {
                return HttpNotFound();
            }
            return View(eventOrder);
        }

        // GET: EventOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventType,DateOfEvent,Venue,NoOfGuest")] EventOrder eventOrder)
        {
            if (ModelState.IsValid)
            {
                db.EventOrder.Add(eventOrder);
                db.SaveChanges();
				ViewBag.IsSuccess="Event Order Successfully";
				return View();
				
				
			}

            return View(eventOrder);
        }

        // GET: EventOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOrder eventOrder = db.EventOrder.Find(id);
            if (eventOrder == null)
            {
                return HttpNotFound();
            }
            return View(eventOrder);
        }

        // POST: EventOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventType,DateOfEvent,Venue,NoOfGuest")] EventOrder eventOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventOrder);
        }

        // GET: EventOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventOrder eventOrder = db.EventOrder.Find(id);
            if (eventOrder == null)
            {
                return HttpNotFound();
            }
            return View(eventOrder);
        }

        // POST: EventOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventOrder eventOrder = db.EventOrder.Find(id);
            db.EventOrder.Remove(eventOrder);
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
