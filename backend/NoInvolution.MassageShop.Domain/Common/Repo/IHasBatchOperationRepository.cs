using MiCake.DDD.Domain;

namespace NoInvolution.MassageShop.Domain.Common
{
    public interface IHasBatchOperationRepository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        Task AddRangeAsync(IEnumerable<TAggregateRoot> items, CancellationToken cancellationToken = default);

        Task DeleteRangeAsync(IEnumerable<TAggregateRoot> items, CancellationToken cancellationToken = default);

        Task DeleteRangeByIdAsync(IEnumerable<TKey> idList, CancellationToken cancellationToken = default);
    }
}
