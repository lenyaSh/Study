using shop.Data.Interfaces;
using shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.mocs {
    public class MockCategory : ICarsCategory {
        public IEnumerable<Category> AllCategories {
            get {
                return new List<Category> {
                    new Category {
                        Name = "Электромобили",
                        Desc = "Современный вид транспорта"
                    },
                    new Category {
                        Name = "Классические автомобили",
                        Desc = "Машины с ДВЗ"
                    }
                };
            }
        }
    }
}
