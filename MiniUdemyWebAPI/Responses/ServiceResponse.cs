namespace MiniUdemyWebAPI.Responses
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } = 200;
        public List<string> Errors { get; set; } = new List<string>();

    }
}
