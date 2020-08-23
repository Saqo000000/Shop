using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRepository,ShopCart shopCart)
        {
            _carRep = carRepository;
            _shopCart = shopCart;
        }
        public IActionResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel() { shopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item!=null)
            {
                _shopCart.AddToCArt(item);
            }
            return RedirectToAction("Index");
        }
    }
}