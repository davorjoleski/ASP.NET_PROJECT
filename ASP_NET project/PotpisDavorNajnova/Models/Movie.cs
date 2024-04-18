using PotpisDavorNajnova.Data.Base;
using PotpisDavorNajnova.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PotpisDavorNajnova.Models
{
    public class Movie :IEntityBase
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Disc { get; set; }

        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //Rel

        public List<Actor_Movie> Actors_Movies { get; set; }


        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
