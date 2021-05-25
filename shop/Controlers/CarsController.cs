using Microsoft.AspNetCore.Mvc;
using shop.Data.Interfaces;
using shop.Data.Models;
using shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controlers {
    public class CarsController : Controller {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat) {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) {
            string _category = category;
            IEnumerable<Car> cars = null;

            string currCategory = string.Empty;
            if(string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else {
                if(string.Equals("electro", _category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Электромобили")).OrderBy(i => i.Id);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", _category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Классические автомобили")).OrderBy(i => i.Id);
                    currCategory = "Автомобили с бензиновыми двигателями";
                }
            }

            currCategory = _category;
            var carObj = new CarsListViewModel {
                AllCars = cars,
                currCategory = currCategory
            };

            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
