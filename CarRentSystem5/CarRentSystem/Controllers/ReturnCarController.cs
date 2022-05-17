using Car_Rent_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rent_System.Controllers
{
    public class ReturnCarController : Controller
    {
        CarRentalEntities1 DB = new CarRentalEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(ReturnCar ReturnCar)
        {
            if (ModelState.IsValid)
            {
                DB.ReturnCars.Add(ReturnCar);
                var car = DB.CarRegisters.SingleOrDefault(carRegister => carRegister.CarNumber == ReturnCar.CarNumber);
                if (car == null)
                {
                    return HttpNotFound("Car Number Not Found!");
                }
                car.Available = "yes";
                DB.Entry(car).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ReturnCar);
        }
        [HttpPost]
        public ActionResult getId(String CarNumber)
        {
            var carn = (from rental in DB.Rentals
                        where rental.CarId == CarNumber
                        select new
                        {
                            StartDate = rental.StartDate,
                            EndDate = rental.EndDate,
                            CustomerId = rental.CustomerId,
                            CarNumber = rental.CarId,
                            Fee = rental.Fee,
                            DelayDays = SqlFunctions.DateDiff("day", rental.EndDate, DateTime.Now)
                        }).ToArray();
            return Json(carn, JsonRequestBehavior.AllowGet);
        }
    }
}
