using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public IActionResult List(string category)
        {
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(item => item.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(iteem => iteem.Category.categoryName.Equals("electric"))
                        .OrderBy(item => item.id);
                    currentCategory = "Classic cars";

                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(iteem => iteem.Category.categoryName.Equals("classic"))
                        .OrderBy(item => item.id);
                    currentCategory = "Electric cars";
                }
                else
                {
                    cars = _allCars.Cars.OrderBy(item => item.id);
                }
            }
            var carObj = new CarsListViewModel()
            {
                AllCars = cars,
                currentCategory = currentCategory

            };
            ViewBag.Title = "Page with automobile";
            return View(carObj);
        }
    }
}