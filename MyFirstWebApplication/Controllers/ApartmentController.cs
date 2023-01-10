using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services;
using System.Collections.Generic;

namespace MyFirstWebApplication.Controllers
{
    public class ApartmentController : Controller
    {
        public IActionResult Index()
        {
            ApartmentDAO apartmentDAO = new ApartmentDAO();
            return View(apartmentDAO.GetAllApartments());
        }

        public IActionResult ApartmentForm()
        {
            return View("AddApartment");
        }

        public IActionResult PaymentForm()
        {
            return View("AddPayment");
        }

        public IActionResult Delete(int id)
        {
            ApartmentDAO apartmentDAO = new ApartmentDAO();
            apartmentDAO.Delete(id);
            return View("InsertYearForm");
        }

        public IActionResult InsertYearForm()
        {
            return View("InsertYearForm");
        }



        public IActionResult TurnoverSheet(ApartmentModel model)
        {
            ApartmentDAO apartmentDAO = new ApartmentDAO();
            return View(apartmentDAO.GetAllApartments(model.Year));
        }

        public IActionResult AddApartment(ApartmentModel model)
        {
            ApartmentDAO apartmentDAO= new ApartmentDAO();
            if (apartmentDAO.CheckApartment(model.Id,model.Year,model.MonthId))
            {
                if (apartmentDAO.Update(model))
                    return View("Success");
                else return View("Failure");
            }
            else
            {
                if (apartmentDAO.InsertApartment(model))
                    return View("Success");
                else return View("Failure");
            }
        }

        public void AddPayment(ApartmentModel model)
        {
            ApartmentDAO apartmentDAO = new ApartmentDAO();
            apartmentDAO.InsertPayment(model);
        }

        
        public IActionResult Details(int id, int year, int month)
        {
            ApartmentDAO apartmentDAO = new();
            return View(apartmentDAO.GetApartmentById(id, year, month));
        }

        public IActionResult Edit(int id, int year, int month)
        {
            ApartmentDAO apartmentDAO = new();
            return View(apartmentDAO.GetApartmentById(id, year, month));
        }

        public IActionResult EditProcess(ApartmentModel model)
        {
            ApartmentDAO apartmentDAO = new ApartmentDAO();
            apartmentDAO.Edit(model);
            return View("TurnoverSheet", apartmentDAO.GetAllApartments(model.Year));
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failure()
        {
            return View();
        }
    }
}
