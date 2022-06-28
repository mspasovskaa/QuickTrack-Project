using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProektSept.Models;

namespace ProektSept.Controllers
{
    [Authorize]
    public class BillsFeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: BillsFees
        public ActionResult Index()
        {
            return View(db.BillsFees.ToList());
        }

        // GET: BillsFees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillsFees billsFees = db.BillsFees.Find(id);
            if (billsFees == null)
            {
                return HttpNotFound();
            }
            return View(billsFees);
        }

        // GET: BillsFees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillsFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Month,Price")] BillsFees billsFees)
        {
            if (ModelState.IsValid)
            {
                db.BillsFees.Add(billsFees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billsFees);
        }
      
        public ActionResult AddBudget(string budget)
        {
            if (budget != null)
            {
                Session["budget"] = budget;
            }
 
            return RedirectToAction("Index");
        }
        // GET: BillsFees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillsFees billsFees = db.BillsFees.Find(id);
            if (billsFees == null)
            {
                return HttpNotFound();
            }
            return View(billsFees);
        }

        // POST: BillsFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Month,Price")] BillsFees billsFees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billsFees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billsFees);
        }

        // GET: BillsFees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillsFees billsFees = db.BillsFees.Find(id);
            if (billsFees == null)
            {
                return HttpNotFound();
            }
            return View(billsFees);
        }

        // POST: BillsFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillsFees billsFees = db.BillsFees.Find(id);
            db.BillsFees.Remove(billsFees);
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
