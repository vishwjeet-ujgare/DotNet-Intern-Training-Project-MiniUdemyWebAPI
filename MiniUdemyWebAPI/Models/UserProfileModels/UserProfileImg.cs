using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.UserProfileModels
{
    public class UserProfileImg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserProfileImgId { get; set; }
       
        
        [Required]
        public string UserProfileImgURL { get; set; } 
    
    
        //key
        public int UserProfileId { get; set; }

        //Navigation
        public UserProfile UserProfile { get; set; }

    }
}
