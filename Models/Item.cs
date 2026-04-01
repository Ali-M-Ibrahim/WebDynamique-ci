using System.ComponentModel.DataAnnotations;

namespace USCJCI.Models
{
    public class Item
    {
        
        public int Id { get; set; }

        [StringLength(50, MinimumLength =5)]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
