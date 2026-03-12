using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarProject //DO NOT Change the namespace name
{
    public class Program //DO NOT Change the class name
    {
        public static void Main(string[] args)
        {
            //Implement the code here
            using (var context = new CarContext())
            {
                var cars = CarRepository.GetAllCarsWithMake(context);
                foreach (var car in cars)
                {
                    // Accessing car.Make triggers the lazy load query
                    Console.WriteLine($"Car Id: {car.Id},      Make: {car.Make.Name.PadRight(10)} Model: {car.Model.PadRight(10)}  Year: {car.Year}");
                }
            }
        }
        
        public static ParameterExpression variableExpr = Expression.Variable(typeof(IEnumerable<Car>), "sampleVar");
        public static Expression GetMyExpression(CarContext context)
        {
            Expression assignExpr = Expression.Assign(variableExpr, Expression.Constant(context.Cars.ToList()));
            return assignExpr;
        }
    }
}
	 	  	    	 	      	  	 	
