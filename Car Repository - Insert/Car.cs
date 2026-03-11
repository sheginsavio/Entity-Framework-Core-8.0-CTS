using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarProject //DO NOT Change the namespace name
{
    public class Car //DO NOT Change the class name
    {
        //Implement the code here
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int Id{ get; set; }
        
        public string Brand { get; set; }
        
        public string Model { get; set; }
        
        public double Price { get; set; }
    }
}