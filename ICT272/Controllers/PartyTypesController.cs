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
    public class PartyTypesController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: PartyTypes
        public ActionResult Index()
        {
            return View(db.partyTypes.ToList());
        }

        // GET: PartyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyType partyType = db.partyTypes.Find(id);
            if (partyType == null)
            {
                return HttpNotFound();
            }
            return View(partyType);
        }

        // GET: PartyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartyTypeID,Type")] PartyType partyType)
        {
            if (ModelState.IsValid)
            {
                db.partyTypes.Add(partyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partyType);
        }

        // GET: PartyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyType partyType = db.partyTypes.Find(id);
            if (partyType == null)
            {
                return HttpNotFound();
            }
            return View(partyType);
        }

        // POST: PartyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartyTypeID,Type")] PartyType partyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partyType);
        }

        // GET: PartyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyType partyType = db.partyTypes.Find(id);
            if (partyType == null)
            {
                return HttpNotFound();
            }
            return View(partyType);
        }

        // POST: PartyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyType partyType = db.partyTypes.Find(id);
            db.partyTypes.Remove(partyType);
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
