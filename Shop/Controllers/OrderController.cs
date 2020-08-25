using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orders;
        private readonly ShopCart shopCart;

        public OrderController(IOrders orders, ShopCart shopCart)
        {
            this.orders = orders;
            this.shopCart = shopCart;
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopItems = shopCart.GetShopItems();
            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You must have items");
            }
            if (ModelState.IsValid)
            {
                orders.CreaateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Order processed successfully";
            return View();
        }
    }
}