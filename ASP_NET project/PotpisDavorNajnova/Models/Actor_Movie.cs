using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace PotpisDavorNajnova.Models
{
    public class Actor_Movie
    {
        [Key]
        public int Movieid { get; set; }

        public Movie Movie { get; set; }


        //actor
        public int ActorId { get; set; }

        public Actor Actor { get; set; }



    }
}
