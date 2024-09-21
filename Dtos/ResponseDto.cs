namespace LibraryManager.Dtos
{
    public class ResponseDto<T>(int status, string message = "", T? data = default)
    {
        public int Status { get; set; } = status;
        public string Message { get; set; } = message;
        public T? Data { get; set; } = data;
    }
}