using System;

namespace CarProject  //DO NOT Change the namespace name
{
    public class CarRepository //DO NOT Change the class name
    {
        public bool AddCar(Car car)
        {
            using (var context = new CarContext())
            {
                // Add the car to the DbSet
                context.Cars.Add(car);
                
                // Save the changes to the database
                int result = context.SaveChanges();
                
                // Return true if at least one row was affected (added successfully)
                return result > 0;
            }
        }
    }
}