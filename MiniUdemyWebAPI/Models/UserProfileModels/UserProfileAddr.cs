using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.UserProfileModels
{
    public class UserProfileAddr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserProfileAddrId { get; set; }


        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; } = string.Empty;


        [Required]
        public string Country { get; set; } = string.Empty;


        [Required]
        public string ZipCode { get; set; } = string.Empty;


        [Required]
        public string Address { get; set; } = string.Empty;


        //Keys
        public int UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]

        //Navigation Properties
        public UserProfile UserProfile { get; set; }


    }
}
