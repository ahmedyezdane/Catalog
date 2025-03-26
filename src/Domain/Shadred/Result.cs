namespace Domain.Shadred;

public class Result
{
    public ResultTypes Type { get; init; }

    public string Message { get; init; }

    public bool IsSuccess => Type == ResultTypes.Success;
    public bool IsFailure => Type == ResultTypes.Failure;

    #region Factory

    public static Result Failure(string message)
    {
        return new Result { Type = ResultTypes.Failure, Message = message };
    }
    public static Result Success(string message)
    {
        return new Result { Type = ResultTypes.Success, Message = message };
    }

    public static Result Failure()
    {
        return new Result { Type = ResultTypes.Failure, Message = "Failed to complete the operation" };
    }
    public static Result Success()
    {
        return new Result { Type = ResultTypes.Success, Message = "Operation completed successfully" };
    }

    #endregion
}

public class Result<TData> : Result
{
    public TData Data { get; set; }

    #region Factory

    public static Result<TData> Failure(string message, TData data)
    {
        return new Result<TData> { Type = ResultTypes.Failure, Message = message, Data = data };
    }
    public static Result<TData> Success(string message, TData data)
    {
        return new Result<TData> { Type = ResultTypes.Success, Message = message, Data = data };
    }

    public static Result<TData> Failure(TData data)
    {
        return new Result<TData> { Type = ResultTypes.Failure, Message = "Failed to complete the operation", Data = data };
    }
    public static Result<TData> Success(TData data)
    {
        return new Result<TData> { Type = ResultTypes.Success, Message = "Operation completed successfully", Data = data };
    }

    #endregion
}

public enum ResultTypes
{
    Success = 1,
    Failure = 2,
}