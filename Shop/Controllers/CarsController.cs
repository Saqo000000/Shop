using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {


        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }
        
        public string Index()
        {
            return "dsdsdsdsd";
        }
        
        public IActionResult List()
        {
            //var cars = _allCars.Cars;
            //@ViewBag.Title = "ba ba ";
            CarsListViewModel carsList = new CarsListViewModel();
            carsList.AllCars= _allCars.Cars;
            carsList.currentCategory = "automobile";
            return View(carsList);
        }
    }
}