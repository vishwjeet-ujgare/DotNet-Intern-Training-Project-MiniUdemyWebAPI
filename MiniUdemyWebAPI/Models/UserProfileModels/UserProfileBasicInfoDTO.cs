using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.Models.UserProfileModels
{
    public class UserProfileBasicInfoDTO
    {
        public int UserProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
