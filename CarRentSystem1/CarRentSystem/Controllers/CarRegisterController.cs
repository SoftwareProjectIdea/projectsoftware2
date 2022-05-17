using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Rent_System.Models;

namespace Car_Rent_System.Controllers
{
    public class CarRegisterController : Controller
    {
        private CarRentalEntities1 db = new CarRentalEntities1();
        public ActionResult Index()
        {
            return View(db.CarRegister.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRegister carRegister = db.CarRegister.Find(id);
            if (carRegister == null)
            {
                return HttpNotFound();
            }
            return View(carRegister);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,CarNumber,CarBrand,CarModel,Available")] CarRegister carRegister)
        {
            if (ModelState.IsValid)
            {
                db.CarRegister.Add(carRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carRegister);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRegister carRegister = db.CarRegister.Find(id);
            if (carRegister == null)
            {
                return HttpNotFound();
            }
            return View(carRegister);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,CarNumber,CarBrand,CarModel,Available")] CarRegister carRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carRegister);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRegister carRegister = db.CarRegister.Find(id);
            if (carRegister == null)
            {
                return HttpNotFound();
            }
            return View(carRegister);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRegister carRegister = db.CarRegister.Find(id);
            db.CarRegister.Remove(carRegister);
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
