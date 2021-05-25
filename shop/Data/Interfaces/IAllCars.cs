using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop.Data.Models;

namespace shop.Data.Interfaces {
    public interface IAllCars {

        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getCarObj(int car_id);

    }
}
