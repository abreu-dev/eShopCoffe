using Framework.Core.Data.Adapters;
using Identity.Domain.Entities;
using Identity.Infra.Data.Entities;

namespace Identity.Infra.Data.Adapters.Interfaces
{
    public interface IUserDataAdapter : IDataAdapter<UserDomain, UserData>
    {
    }
}
