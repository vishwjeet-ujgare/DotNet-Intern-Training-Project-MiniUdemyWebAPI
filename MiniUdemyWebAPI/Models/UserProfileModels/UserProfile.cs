using Microsoft.Identity.Client;
using MiniUdemyWebAPI.Models.UserModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.UserProfileModels
{
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserProfileId { get; set; }


        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }


        [Required]
        [MaxLength(60)]
        public string Headline { get; set; }


        //Require coustome validation which will implement later for 50 words 
        [Required]
        [MinLength(255)]
        [MaxLength(500)]
        public string Bio { get; set; } = string.Empty;

        // optional fields
        public string OtherLink { get; set; } = string.Empty;

        public string LinkedInLink { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


    //Forign key
        public int UserId { get; set; }
        [ForeignKey("UserId")]


        //Navigation Properties
        public User User { get; set; }

        public UserProfileImg UserProfileImg { get; set; }

        public UserProfileAddr UserProfileAddr { get; set; }



    }
}
