namespace eShopCoffe.Core.Validators.Interfaces
{
    public interface IResult
    {
        bool HasSucceed { get; set; }
        string? ErrorCode { get; set; }
        string? ErrorMessage { get; set; }
    }

    public interface IResult<TItem> : IResult
    {
        TItem? Item { get; set; }
    }
}
