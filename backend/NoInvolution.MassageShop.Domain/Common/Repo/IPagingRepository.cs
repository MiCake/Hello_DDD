using MiCake.DDD.Domain;
using MiCake.DDD.Extensions.Paging;

namespace NoInvolution.MassageShop.Domain.Common
{
    public interface IPagingRepository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>, IRepositoryHasPagingQuery<TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {
    }
}
