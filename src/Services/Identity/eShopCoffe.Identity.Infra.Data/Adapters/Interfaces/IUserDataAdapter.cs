using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Infra.Data.Entities;

namespace eShopCoffe.Identity.Infra.Data.Adapters.Interfaces
{
    public interface IUserDataAdapter : IDataAdapter<UserDomain, UserData>
    {
    }
}
