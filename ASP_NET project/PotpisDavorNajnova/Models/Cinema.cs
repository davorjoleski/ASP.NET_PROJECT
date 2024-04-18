using System.ComponentModel.DataAnnotations;

namespace PotpisDavorNajnova.Models
{
    public class Cinema
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Cinema logo")]

        public string Cinemalogo { get; set; }

        [Display(Name = "Cinema name")]

        public string FullName { get; set; }

        [Display(Name = "Description")]

        public string Disc { get; set; }

        //Relationship

        public List<Movie> Movies { get; set; }


    }
}
