using Microsoft.AspNetCore.Mvc;
using shop.Data.Interfaces;
using shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controlers {
    public class HomeController : Controller{
        private readonly IAllCars _carRepository;

        public HomeController(IAllCars carRepository) {
            _carRepository = carRepository;
        }

        public ViewResult Index() {
            var homeCars = new HomeViewModel {
                FavorCars = _carRepository.getFavCars
            };

            return View(homeCars);
        }
    }
}
