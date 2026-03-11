using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace CarProject //DO NOT Change the namespace name
{
    public class Program //DO NOT Change the class name
    {
        public static void Main(string[] args)
        {
            using (var context = new CarContext())
            {
                // --- DATABASE RESET & SEEDING BLOCK ---
                // Deletes the old DB from the previous exercise and creates a new one
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Seed the sample data if it doesn't exist
                if (!context.Makes.Any())
                {
                    context.Makes.AddRange(
                        new Make { Id = 101, Name = "Toyota" },
                        new Make { Id = 102, Name = "Ford" },
                        new Make { Id = 103, Name = "Honda" },
                        new Make { Id = 104, Name = "BMW" }
                    );
                    context.Cars.AddRange(
                        new Car { Id = 1, Model = "Camry", Year = 1999, MakeId = 101 },
                        new Car { Id = 2, Model = "Mustang", Year = 2002, MakeId = 102 },
                        new Car { Id = 3, Model = "Sienna", Year = 2000, MakeId = 101 },
                        new Car { Id = 4, Model = "Civic", Year = 1998, MakeId = 103 },
                        new Car { Id = 5, Model = "X3", Year = 2002, MakeId = 104 }
                    );
                    context.SaveChanges();
                }
                // --------------------------------------

                // Execute the eager loading query
                var cars = CarRepository.GetAllCarsWithMake(context);

                // Print the results matching the required sample output
                foreach (var car in cars)
                {
                    Console.WriteLine($"Car Id: {car.Id},        Make: {car.Make?.Name},        Model: {car.Model},        Year: {car.Year}");
                }
            }
        }
        
        public static ParameterExpression variableExpr = Expression.Variable(typeof(IEnumerable<Car>), "sampleVar");
        public static Expression GetMyExpression(CarContext context)
        {
            // The exact LINQ Query Expression for eager loading
            Expression assignExpr = Expression.Assign(variableExpr, Expression.Constant(context.Cars.Include(c => c.Make).ToList()));
            return assignExpr;
        }
    }
}