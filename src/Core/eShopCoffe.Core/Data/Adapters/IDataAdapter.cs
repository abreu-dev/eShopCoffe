using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Core.Data.Adapters
{
    public interface IDataAdapter<TEntityDomain, TEntityData>
        where TEntityDomain : EntityDomain
        where TEntityData : EntityData
    {
        TEntityDomain? Transform(TEntityData? data);
        IEnumerable<TEntityDomain> Transform(IEnumerable<TEntityData> datas);

        TEntityData? Transform(TEntityDomain? domain);
        IEnumerable<TEntityData> Transform(IEnumerable<TEntityDomain> domains);
    }
}
