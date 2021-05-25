using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Data.Models {
    public class Category {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public List<Car> Cars { set; get; }


    }
}
