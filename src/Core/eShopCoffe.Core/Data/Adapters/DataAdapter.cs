using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Core.Data.Adapters
{
    public abstract class DataAdapter<TEntityDomain, TEntityData> : IDataAdapter<TEntityDomain, TEntityData>
        where TEntityDomain : EntityDomain
        where TEntityData : EntityData
    {
        public abstract TEntityDomain? Transform(TEntityData? data);

        public IEnumerable<TEntityDomain> Transform(IEnumerable<TEntityData> datas)
        {
            var result = new List<TEntityDomain>();

            foreach (var data in datas)
            {
                var domain = Transform(data);
                if (domain != null)
                {
                    result.Add(domain);
                }
            }

            return result;
        }

        public abstract TEntityData? Transform(TEntityDomain? domain);

        public IEnumerable<TEntityData> Transform(IEnumerable<TEntityDomain> domains)
        {
            var result = new List<TEntityData>();

            foreach (var domain in domains)
            {
                var data = Transform(domain);
                if (data != null)
                {
                    result.Add(data);
                }
            }

            return result;
        }
    }
}
