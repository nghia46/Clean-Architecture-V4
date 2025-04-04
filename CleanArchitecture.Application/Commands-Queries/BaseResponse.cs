using NUlid;

namespace CleanArchitecture.Application.Commands_Queries;

public class BaseResponse<T>
{
    public required string Id { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    internal static BaseResponse<T> NotFound(string message = "Không tìm thấy dữ liệu")
    {
        return new BaseResponse<T>
        {
            Id = Ulid.NewUlid().ToString(),
            StatusCode = 404,
            Message = message,
            Success = false,
            Timestamp = DateTimeOffset.UtcNow + TimeSpan.FromHours(7)
        };
    }

    internal static BaseResponse<T> SuccessReturn(T classInstance, string message = "Thành công")
    {
        return new BaseResponse<T>
        {
            Id = Ulid.NewUlid().ToString(),
            StatusCode = 200,
            Message = message,
            Success = true,
            Data = classInstance,
            Timestamp = DateTimeOffset.UtcNow + TimeSpan.FromHours(7)
        };
    }
    internal static BaseResponse<T> InternalServerError(string? message = "Server error")
    {
        return new BaseResponse<T>
        {
            Id = Ulid.NewUlid().ToString(),
            StatusCode = 500,
            Message = message,
            Success = false,
            Timestamp = DateTimeOffset.UtcNow + TimeSpan.FromHours(7)
        };
    }

    internal static BaseResponse<T> Unauthorized()
    {
        return new BaseResponse<T>
        {
            Id = Ulid.NewUlid().ToString(),
            StatusCode = 401,
            Message = "Không có quyền truy cập, chưa đăng nhập hoặc phiên làm việc hết hạn",
            Success = false,
            Timestamp = DateTimeOffset.UtcNow + TimeSpan.FromHours(7)
        };
    }

    internal static BaseResponse<T> BadRequest(string message = "Yêu cầu không hợp lệ")
    {
        return new BaseResponse<T>
        {
            Id = Ulid.NewUlid().ToString(),
            StatusCode = 400,
            Message = message,
            Success = false,
            Timestamp = DateTimeOffset.UtcNow + TimeSpan.FromHours(7)
        };
    }
    internal static BaseResponse<T> CustomResponse(int statusCodes,string message, bool success, List<string> errors) 
    {
        return new BaseResponse<T>
        {
            Id = Ulid.NewUlid().ToString(),
            StatusCode = statusCodes,
            Message = message,
            Success = success,
            Errors = errors,
            Timestamp = DateTimeOffset.UtcNow + TimeSpan.FromHours(7)
        };
    }
}