using MiCake.DDD.Domain;
using Microsoft.EntityFrameworkCore;
using NoInvolution.MassageShop.Domain.Common;
using Z.EntityFramework.Plus;

namespace NoInvolution.MassageShop.EntityFramework.Core
{
    /// <summary>
    /// 具有批量增删以及搜索行为的仓库
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TShortInfo"></typeparam>
    /// <typeparam name="TAggregateRoot"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    internal abstract class BatchOperationEFRepository<TDbContext, TShortInfo, TAggregateRoot, TKey> : SearchShortInfoEFRepository<TDbContext, TShortInfo, TAggregateRoot, TKey>, IHasBatchOperationRepository<TAggregateRoot, TKey>
         where TDbContext : DbContext
         where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        public BatchOperationEFRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task AddRangeAsync(IEnumerable<TAggregateRoot> items, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);
            await dbset.AddRangeAsync(items, cancellationToken);
        }

        public async Task DeleteRangeAsync(IEnumerable<TAggregateRoot> items, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);
            dbset.RemoveRange(items);
        }

        public async Task DeleteRangeByIdAsync(IEnumerable<TKey> idList, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);
            await dbset.Where(s => idList.Contains(s.Id)).DeleteAsync(cancellationToken);
        }
    }
}
