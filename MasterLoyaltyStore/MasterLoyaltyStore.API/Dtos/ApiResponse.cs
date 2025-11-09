namespace MasterLoyaltyStore.API.Dtos;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; } = default!;


    public ApiResponse(bool success, int statusCode, string message, T data)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
        Data = data;
    }



    public static ApiResponse<T> SuccessResponse(T data, string message)
    {
        return new ApiResponse<T>(true,(int)StatusCodes.Status200OK, message, data);
    }

    public static ApiResponse<T> SuccessCreatedResponse(T data, string message)
    {
        return new ApiResponse<T>(true,(int)StatusCodes.Status201Created, message, data);
    }

    public static ApiResponse<T> ErrorResponse(int statusCode, string message)
    {
        return new ApiResponse<T>(false,statusCode, message, default!);
    }
}