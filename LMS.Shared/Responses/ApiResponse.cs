namespace LMS.Shared.Responses;

public class ApiResponse<T>
{
    public bool success { get; set; }

    public string Message { get; set; } = string.Empty;

    public T? Data { get; set; }


    public static ApiResponse<T> Success(
        T data,
        string message = "")
    {
        return new ApiResponse<T>
        {
            success = true,
            Message = message,
            Data = data
        };
    }



    public static ApiResponse<T> Fail(
        string message)
    {
        return new ApiResponse<T>
        {
            success = false,
            Message = message,
            Data = default
        };
    }
}
