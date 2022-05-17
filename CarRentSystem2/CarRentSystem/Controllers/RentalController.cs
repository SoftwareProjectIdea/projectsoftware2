using Car_Rent_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rent_System.Controllers
{
    public class RentalController : Controller
    {
        CarRentalEntities1 DB = new CarRentalEntities1();
        // GET: Rent
        public ActionResult Index()
        {
            var result = (from rental in DB.Rentals
                          join carRegister in  DB.CarRegisters on rental.CarId equals carRegister.CarNumber
                          select new RentViewModel
                          {
                              Id = rental.Id,
                              CarId = rental.CarId,
                              CustomerId = rental.CustomerId,
                              Fee = rental.Fee,
                              StartDate = rental.StartDate,
                              EndDate = rental.EndDate,
                              Available = carRegister.Available
                          }).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult getCarDetails()
        {
            var Car = DB.CarRegisters.ToList();
            return Json(Car, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult getId(int Id)
        {
            var Customer = (from customer in DB.Customers
                            where customer.CustomerId == Id
                            select customer.CustomerName).ToList();
            return Json(Customer, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult getAvailableOrNot(string CarNumber)
        {
            var Available = (from carRegister in DB.CarRegisters
                             where carRegister.CarNumber == CarNumber
                             select carRegister.Available).FirstOrDefault();
            return Json(Available, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Save(Rental Rent)
        {
            if (ModelState.IsValid)
            {
                DB.Rentals.Add(Rent);
                var car = DB.CarRegisters.SingleOrDefault(carRegister => carRegister.CarNumber == Rent.CarId);
                if (car == null)
                {
                    return HttpNotFound("Car Number Not Found!");
                }
                car.Available = "no";
                DB.Entry(car).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Rent);
        }
    }
}
