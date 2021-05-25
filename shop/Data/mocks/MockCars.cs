using shop.Data.Interfaces;
using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shop.Data.mocs {
    public class MockCars : IAllCars {

        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                    new Car {
                        Name = "Tesla",
                        ShortDesc = "Быстрый автомобиль",
                        FullDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg",
                        Price = 45000,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/ford.jpg",
                        Price = 11000,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "BMW W3",
                        ShortDesc = "Дерзкий и стильный",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/bmv.jpg",
                        Price = 65000,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "Mercedes C class",
                        ShortDesc = "Уютный и большой",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        Price = 40000,
                        isFavourite = false,
                        Available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/nissan.jpg",
                        Price = 14000,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get ; set; }

        public Car getCarObj(int car_id) {
            throw new NotImplementedException();
        }
    }
}
