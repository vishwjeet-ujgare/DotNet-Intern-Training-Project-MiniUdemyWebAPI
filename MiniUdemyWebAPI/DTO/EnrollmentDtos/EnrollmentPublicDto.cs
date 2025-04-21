using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.DTO.EnrollmentDtos
{
    public enum EnrollmentStatus
    {
        Enrolled,
        Completed,
        Cancelled,
        Expired,
        Failed,
    }
    public class EnrollmentPublicDto
    {

        [Required]
        public string Status { get; set; } = EnrollmentStatus.Enrolled.ToString();

        public int TotalEnrolledCount { get; set; } = 0;

    }
}
