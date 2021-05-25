using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Models {
    public class Car {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public string img { get; set; }
        public ushort Price { get; set; }
        public bool isFavourite { get; set; }
        public bool Available { get; set; }
        public int CategoryId{ get; set; }
        public virtual Category Category { get; set; }
    }
}
