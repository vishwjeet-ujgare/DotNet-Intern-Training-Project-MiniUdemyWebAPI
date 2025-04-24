namespace MiniUdemyWebAPI.Models
{
    public class Response
    {



        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? Title { get; set; }
  
        public String? Status { get; set; }
        public string? SystemError { get; set; }
        public object? ErrorObject { get; set; }

    }
}
