namespace GymApi;

public class GenericsResponse
{
    public GenericsResponse()
    {

    }

    public BaseReponse OkResponse(String message = "", object data = null)
    {
        return new BaseReponse
        {
            StatusCode = 200,
            StatusText = "OK_STATUS_TEXT",
            Message = message != null && message.Trim().Length > 0 ? message : "Operation completed successfully",
            Data = data ?? new object { }
        };
    }

    public BaseReponse CreatedResponse(String message = "", object data = null)
    {
        return new BaseReponse
        {
            StatusCode = 201,
            StatusText = "CREATED",
            Message = message != null && message.Trim().Length > 0 ? message : "Resource created.",
            Data = data ?? new object { }
        };
    }

    public BaseReponse NotFoundResponse(String message = "", object data = null)
    {
        return new BaseReponse
        {
            StatusCode = 404,
            StatusText = "NOT_FOUND",
            Message = message != null && message.Trim().Length > 0 ? message : "Resource not founded.",
            Data = data ?? new object { }
        };
    }

    public BaseReponse BadRequestResponse(String message = "", object data = null)
    {
        return new BaseReponse
        {
            StatusCode = 400,
            StatusText = "BAD_REQUEST",
            Message = message != null && message.Trim().Length > 0 ? message : "Bad request exception, check your data",
            Data = data ?? new object { }
        };
    }

    public BaseReponse InternalServerResponse(String message = "", object data = null)
    {
        return new BaseReponse
        {
            StatusCode = 500,
            StatusText = "INTERNAL_SERVER_ERROR",
            Message = message != null && message.Trim().Length > 0 ? message : "Server error, contact an administrator",
            Data = data ?? new object { }
        };
    }

    public BaseReponse UnauthorizedResponse(String message = "", object data = null)
    {
        return new BaseReponse
        {
            StatusCode = 401,
            StatusText = "INTERNAL_SERVER_ERROR",
            Message = message != null && message.Trim().Length > 0 ? message : "You are not authorized to perform this action, check your permissions.",
            Data = data ?? new object { }
        };
    }

}
