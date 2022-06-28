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
    public class FoodDrinksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FoodDrinks
        public ActionResult Index()
        {
            return View(db.FoodDrinks.ToList());
        }
        public ActionResult AddBudget(string budget)
        {
            if (budget != null)
            {
                Session["budget2"] = budget;
            }

            return RedirectToAction("Index", "FoodDrinks");
        }

        // GET: FoodDrinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinks foodDrinks = db.FoodDrinks.Find(id);
            if (foodDrinks == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinks);
        }

        // GET: FoodDrinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodDrinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Quantity,Price")] FoodDrinks foodDrinks)
        {
            if (ModelState.IsValid)
            {
                db.FoodDrinks.Add(foodDrinks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodDrinks);
        }

        // GET: FoodDrinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinks foodDrinks = db.FoodDrinks.Find(id);
            if (foodDrinks == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinks);
        }

        // POST: FoodDrinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Quantity,Price")] FoodDrinks foodDrinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodDrinks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodDrinks);
        }

        // GET: FoodDrinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodDrinks foodDrinks = db.FoodDrinks.Find(id);
            if (foodDrinks == null)
            {
                return HttpNotFound();
            }
            return View(foodDrinks);
        }

        // POST: FoodDrinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodDrinks foodDrinks = db.FoodDrinks.Find(id);
            db.FoodDrinks.Remove(foodDrinks);
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
