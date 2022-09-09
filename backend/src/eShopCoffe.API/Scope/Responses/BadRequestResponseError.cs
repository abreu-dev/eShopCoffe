namespace eShopCoffe.API.Scope.Responses
{
    public class BadRequestResponseError
    {
        public string Type { get; set; }
        public string Error { get; set; }

        public BadRequestResponseError(string type, string error)
        {
            Type = type;
            Error = error;
        }
    }
}
