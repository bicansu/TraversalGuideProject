using System.ComponentModel.DataAnnotations;

namespace CapstoneProject_ApiLayer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
