namespace LMS.Shared.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public T? Data { get; set; }

    public List<ApiError> Errors { get; set; }
        = new();

    public static ApiResponse<T> SuccessResult(
        T data,
        string message = "")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static ApiResponse<T> FailResult(
        string message)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message
        };
    }

    public static ApiResponse<T> FailResult(
        List<ApiError> errors)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Errors = errors
        };
    }
}