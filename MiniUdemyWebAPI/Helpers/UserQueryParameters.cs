namespace MiniUdemyWebAPI.Helpers
{
    public class UserQueryParameters
    {
        // The current page number for pagination, default is 1
        public required int PageNumber { get; set; } = 1;

        // The number of items to display per page, default is 10
        public required int PageSize { get; set; } = 10;

        // Determines if the sorting should be in descending order, default is false (ascending)
        public bool IsDescending { get; set; } = false;

        // Filter users based on their role, can be null
        // Example: "Student" to filter only student users
        public required string UserType { get; set; }

        // The term to search for in user data, can be null
        // Example: "John" to filter users whose names contain "John"
        public string? SearchTerm { get; set; } = null;

        //// The field to sort the user data by, can be null
        //// Example: "Name" to sort users by their names
        //public string? SortBy { get; set; }=null;

        //// Filter users based on their active status, can be null
        //// Example: true to filter only active users
        //public bool? IsActive { get; set; }


        //// Filter users based on email verification status, default is false
        //// Example: true to filter only verified users
        //public bool? IsVerified { get; set; } = false;

        //// Filter users based on their creation date, can be null
        //// Example: DateTime.Today to filter users created today
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? CreatedAtTo { get; set; }


    }
}
