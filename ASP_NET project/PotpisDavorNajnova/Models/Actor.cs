using PotpisDavorNajnova.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace PotpisDavorNajnova.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Profile Picture ")]

        [Required (ErrorMessage= "Profile pic is required")]
      //  [Required (ErrorMessage ="Profile Picutre eror need full name")]
        public string ProfPicUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name  is required")]

        [StringLength (50,MinimumLength =3,ErrorMessage ="Full Name must be between 3 and 50 chars")]

        public string FullName { get; set; }
        [Display(Name = "Bio")]

        public string Bio { get; set; }



        //relationship

        public List<Actor_Movie> Actor_Movies { get; set; }

    }
}
