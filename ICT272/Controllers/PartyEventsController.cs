using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICT272.DAL;
using ICT272.Models;

namespace ICT272.Controllers
{
    public class PartyEventsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: PartyEvents
        public ActionResult Index()
        {
            var partyEvents = db.PartyEvents.Include(p => p.PartyType);
            return View(partyEvents.ToList());
        }

        // GET: PartyEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyEvent partyEvent = db.PartyEvents.Find(id);
            if (partyEvent == null)
            {
                return HttpNotFound();
            }
            return View(partyEvent);
        }

        // GET: PartyEvents/Create
        public ActionResult Create()
        {
            ViewBag.PartyTypeID = new SelectList(db.partyTypes, "PartyTypeID", "Type");
            return View();
        }

        // POST: PartyEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartyEventID,PartyTypeID,EventTime")] PartyEvent partyEvent)
        {
            if (ModelState.IsValid)
            {
                db.PartyEvents.Add(partyEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartyTypeID = new SelectList(db.partyTypes, "PartyTypeID", "Type", partyEvent.PartyTypeID);
            return View(partyEvent);
        }

        // GET: PartyEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyEvent partyEvent = db.PartyEvents.Find(id);
            if (partyEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartyTypeID = new SelectList(db.partyTypes, "PartyTypeID", "Type", partyEvent.PartyTypeID);
            return View(partyEvent);
        }

        // POST: PartyEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartyEventID,PartyTypeID,EventTime")] PartyEvent partyEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartyTypeID = new SelectList(db.partyTypes, "PartyTypeID", "Type", partyEvent.PartyTypeID);
            return View(partyEvent);
        }

        // GET: PartyEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyEvent partyEvent = db.PartyEvents.Find(id);
            if (partyEvent == null)
            {
                return HttpNotFound();
            }
            return View(partyEvent);
        }

        // POST: PartyEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyEvent partyEvent = db.PartyEvents.Find(id);
            db.PartyEvents.Remove(partyEvent);
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
