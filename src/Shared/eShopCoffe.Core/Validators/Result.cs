using eShopCoffe.Core.Validators.Interfaces;

namespace eShopCoffe.Core.Validators
{
    public class Result : IResult
    {
        public bool HasSucceed { get; set; }

        public string? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public static Result Success()
        {
            return new Result()
            {
                HasSucceed = true
            };
        }

        public static Result Failure(string errorCode, string errorMessage)
        {
            return new Result()
            {
                HasSucceed = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
    }

    public class Result<TItem> : Result, IResult<TItem>
    {
        public TItem? Item { get; set; }

        public static Result<TItem> Success(TItem item)
        {
            return new Result<TItem>()
            {
                HasSucceed = true,
                Item = item
            };
        }
        public static new Result<TItem> Failure(string errorCode, string errorMessage)
        {
            return new Result<TItem>()
            {
                HasSucceed = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
    }
}
