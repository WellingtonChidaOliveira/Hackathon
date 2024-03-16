using Hackathon.Domain.Util;

namespace Hackathon.Domain.Util
{
    public class Result
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }

  
}

public static class ReturnResult
{
    public static Result Ok(string message, object? data = null)
    {
        return new Result
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static Result Fail(string message, object? data = null)
    {
        return new Result
        {
            Success = false,
            Message = message,
            Data = data
        };
    }

}
