using System.ComponentModel.DataAnnotations;

namespace MotionPictureDataBase.Models
    //change to lowercase\\
   
{
    public class Movie
    {
        public int ID { get; set; } //if setter removied then can be only changed in constructor could also do a duplicate private id with gettter/setter, then a public with only a getter
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(0,int.MaxValue)] //chage to current_year
        //need validation to not be zero or negative
        public int ReleaseYear { get; set;} //="" would make a default
        
    }
}
