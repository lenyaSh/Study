using Microsoft.AspNetCore.Mvc;
using shop.Data.Interfaces;
using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controlers {
    public class OrderController : Controller {
        private readonly IAllOrders AllOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders AllOrders, ShopCart shopCart) {
            this.AllOrders = AllOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order) {

            shopCart.ListShopItems = shopCart.GetShopItems();

            if(shopCart.ListShopItems.Count == 0) {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            //Параметр IsValid будет true, если все поля, заполненные в Checkout
            //пройдут указанные проверки (по длине и типу данных)
            //иначе параметр будет false
            if(ModelState.IsValid) {
                AllOrders.CreateOrder(order);

                //если все в порядке, редиректим на функцию complete
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан!";
            return View();

        }
    }
}
