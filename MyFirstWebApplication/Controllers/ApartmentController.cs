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

        public void AddApartment(ApartmentModel model)
        {
            ApartmentDAO apartmentDAO= new ApartmentDAO();
            apartmentDAO.InsertApartment(model);
            View("Index");
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
            return View();
        }

    }
}
