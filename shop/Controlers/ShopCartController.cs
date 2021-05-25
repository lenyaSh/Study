using Microsoft.AspNetCore.Mvc;
using shop.Data.Interfaces;
using shop.Data.Models;
using shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controlers {
    public class ShopCartController : Controller{
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart) {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index() {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id) {
            var item = _carRepository.Cars.FirstOrDefault(i => i.Id == id);
            if(item != null) {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }


    }
}
