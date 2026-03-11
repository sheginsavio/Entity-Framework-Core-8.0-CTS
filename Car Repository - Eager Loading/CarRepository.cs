using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarProject  //DO NOT Change the namespace name
{
    public class CarRepository //DO NOT Change the class name
    {
        public static IEnumerable<Car> GetAllCarsWithMake(CarContext context)
        {
            // Eager loading using the Include method
            return context.Cars.Include(c => c.Make).ToList();
        }
    }
}