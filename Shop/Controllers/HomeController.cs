using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        public HomeController(IAllCars carRepository)
        {
            _carRep = carRepository;
        }
        public IActionResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                favCars = _carRep.GetFavCars
            };

            return View(homeCars);
        }
    }
}