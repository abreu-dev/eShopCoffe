using System.Runtime.Serialization;

namespace eShopCoffe.Core.Exceptions
{
    [Serializable]
    public class EShopCoffeException : Exception
    {
        public EShopCoffeException(string? message) : base(message)
        {
        }

        protected EShopCoffeException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
