using System.ComponentModel.DataAnnotations;

namespace USCJCI.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }


    }
}
