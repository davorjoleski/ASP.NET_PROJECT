using System.ComponentModel.DataAnnotations;

namespace PotpisDavorNajnova.Models
{
    public class Producer
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "ProfielPictureURl")]

        public string ProfPicUrl { get; set; }

        [Display(Name = "FullName")]

        public string FullName { get; set; }

        [Display(Name = "Bio")]

        public string Bio { get; set; }



        //Relationship
            public List<Movie>Movies  { get; set; }
    }
}
