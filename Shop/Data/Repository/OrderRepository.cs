using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrderRepository : IOrders
    {
        private readonly AppDBContext appDBContent;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDBContext appDBContent,ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appDBContent = appDBContent;
        }
        public void CreaateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Orders.Add(order);
            appDBContent.SaveChanges();
            var items = shopCart.listShopItems;
            //var items = shopCa rt.GetShopItems();
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = item.car.id,
                    orderId = appDBContent.Orders.OrderByDescending(item => item.id).First().id,// order.id,
                    price = item.car.price,
                };
                appDBContent.OrderDetails.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
