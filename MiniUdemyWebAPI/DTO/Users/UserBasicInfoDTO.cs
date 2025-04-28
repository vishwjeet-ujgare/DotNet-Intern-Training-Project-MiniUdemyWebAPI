namespace MiniUdemyWebAPI.DTO.Users
{
    public class UserBasicInfoDTO
    {
        public String Id { get; set; }
        public string? FirstName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
