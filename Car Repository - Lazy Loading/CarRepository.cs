using Microsoft.EntityFrameworkCore;

namespace CarProject  //DO NOT Change the namespace name
{
    public class CarRepository //DO NOT Change the class name
    {
        //Implement the code here
        public static IEnumerable<Car> GetAllCarsWithMake(CarContext context)
        {
            return context.Cars.ToList();
        }
    }
}

	 	  	    	 	      	  	 	
