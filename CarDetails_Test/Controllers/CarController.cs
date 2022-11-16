using CarDetails_Test.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDetails_Test.Controllers
{
    public class CarController : Controller
    {
        ManPowerTestEntities db = new ManPowerTestEntities();
        // GET: Car
        public ActionResult Index()
        {
            var listofData = db.tblCarDetails.ToList();
            return View(listofData);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(tblCarDetail obj)
        {
            try
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        db.tblCarDetails.Add(obj);
                        db.SaveChanges();
                        ViewBag.Message = "Data Insert Successfully";
                    }

                    return RedirectToAction("Index", "Car");
                }
                catch
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.tblCarDetails.Where(x => x.CarId == id).FirstOrDefault();
            return View(data);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(tblCarDetail obj)
        {
            try
            {
                var data = db.tblCarDetails.Where(x => x.CarId == obj.CarId).FirstOrDefault();
                if (data != null)
                {
                    data.Brand = obj.Brand;
                    data.Model = obj.Model;
                    data.CarName = obj.CarName;
                    data.Price = obj.Price;
                    data.New = obj.New;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Car");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.tblCarDetails.Where(x => x.CarId == id).FirstOrDefault();
            db.tblCarDetails.Remove(data);
            db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("Index");
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
            }
    }
}
