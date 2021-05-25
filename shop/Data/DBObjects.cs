using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data {
    public class DBObjects {
        public static void Initial(AppDBContent content) {

            if (!content.Category.Any()) {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any()) {
                content.AddRange(
                    new Car {
                        Name = "Tesla",
                        ShortDesc = "Быстрый автомобиль",
                        FullDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg",
                        Price = 45000,
                        isFavourite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/ford.jpg",
                        Price = 11000,
                        isFavourite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car {
                        Name = "BMW W3",
                        ShortDesc = "Дерзкий и стильный",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/bmv.jpg",
                        Price = 65000,
                        isFavourite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car {
                        Name = "Mercedes C class",
                        ShortDesc = "Уютный и большой",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        Price = 40000,
                        isFavourite = false,
                        Available = false,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономный",
                        FullDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/nissan.jpg",
                        Price = 14000,
                        isFavourite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    }

                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> Category;

        public static Dictionary<string, Category> Categories {
            get {
                if (Category == null) {
                    var list = new Category[] {
                        new Category {
                           Name = "Электромобили",
                           Desc = "Современный вид транспорта"
                        },
                        new Category {
                           Name = "Классические автомобили",
                           Desc = "Машины с ДВЗ"
                        }
                    };

                    Category = new Dictionary<string, Category>();
                    foreach(Category element in list) {
                        Category.Add(element.Name, element);
                    }
                }

                return Category;
            }
        }
    }
}
