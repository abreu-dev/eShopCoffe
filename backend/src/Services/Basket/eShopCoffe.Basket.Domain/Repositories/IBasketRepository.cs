using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Core.Domain.Repositories.Interfaces;

namespace eShopCoffe.Basket.Domain.Repositories
{
    public interface IBasketRepository : IRepository<BasketDomain>
    {
        BasketDomain? GetByUserId(Guid userId);
    }
}
