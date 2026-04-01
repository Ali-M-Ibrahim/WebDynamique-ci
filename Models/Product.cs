using System.ComponentModel.DataAnnotations;

namespace USCJCI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is mandatory")]
        [StringLength(10, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Range(1,1000)]
        public double Price { get; set; }

        [Required]
        public string Description {  get; set; }
    }
}
