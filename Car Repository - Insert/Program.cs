namespace CarProject //DO NOT Change the namespace name
{
    public class Program //DO NOT Change the class name
    {
        public static void Main(string[] args)
        {
            //Implement the code here
            
            Console.WriteLine("Enter car id");
            int id = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter car brand");
            string brand = Console.ReadLine();
            
            Console.WriteLine("Enter car model");
            string model = Console.ReadLine();
            
            Console.WriteLine("Enter car price");
            double price = Convert.ToDouble(Console.ReadLine());
            
            Car newCar = new Car(){
                Id = id,
                Brand = brand,
                Model = model,
                Price = price
            };
            
            CarRepository repository = new CarRepository();
            bool isSuccess = repository.AddCar(newCar);
            
            if(isSuccess){
                Console.WriteLine("\nDetails Added Successfully");
            }
        }
    }
}
	 	  	    	 	      	  	 	
