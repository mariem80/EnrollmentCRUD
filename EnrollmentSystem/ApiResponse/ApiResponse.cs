namespace EnrollmentSystem.WebAPIs.ApiResponse;

public class ApiResponse<T>
{
    public int Status { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public Dictionary<string, string[]> Errors { get; set; }

    public ApiResponse(int status, T data, string message, Dictionary<string, string[]> errors = null)
    {
        Status = status;
        Data = data;
        Message = message;
        Errors = errors;
    }
}
public class ApiResponse : ApiResponse<object>
{
    public ApiResponse(int status, object data, string message) : base(status, data, message)
    {
    }
}