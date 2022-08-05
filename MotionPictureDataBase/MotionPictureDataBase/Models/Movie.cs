using System.ComponentModel.DataAnnotations;

namespace MotionPictureDataBase.Models
   
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        //need validation to not be zero or negative
        public int ReleaseYear { get; set;}
        
    }
}
