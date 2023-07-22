namespace server.Model
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T? Data { get; set; }
    }
}