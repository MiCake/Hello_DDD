using MiCake.Audit;
using MiCake.DDD.Domain;
using MiCake.DDD.Extensions.Paging;
using MiCake.EntityFrameworkCore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NoInvolution.MassageShop.EntityFramework.Core
{
    /// <summary>
    /// 具有分页查找功能的仓储
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TAggregateRoot"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    internal class PagingEFRepository<TDbContext, TAggregateRoot, TKey> : EFRepository<TDbContext, TAggregateRoot, TKey>, IRepositoryHasPagingQuery<TAggregateRoot, TKey>
         where TDbContext : DbContext
         where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        public PagingEFRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public virtual async Task<PagingQueryResult<IEnumerable<TAggregateRoot>>> PagingQueryAsync(PagingQueryModel queryModel, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);

            IEnumerable<TAggregateRoot> result;
            if (typeof(IHasCreationTime).IsAssignableFrom(typeof(TAggregateRoot)))
            {
                result = await dbset.OrderBy(s => ((IHasCreationTime)s).CreationTime).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum).ToListAsync(cancellationToken);
            }
            else
            {
                result = await dbset.Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum).ToListAsync(cancellationToken);
            }
            var count = await GetCountAsync(cancellationToken);

            return new PagingQueryResult<IEnumerable<TAggregateRoot>>(queryModel.PageIndex, count, result);
        }

        public virtual async Task<PagingQueryResult<IEnumerable<TAggregateRoot>>> PagingQueryAsync<TOrderKey>(PagingQueryModel queryModel, Expression<Func<TAggregateRoot, TOrderKey>> orderSelector, bool asc = true, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);

            IEnumerable<TAggregateRoot> result;
            if (asc)
            {
                result = await dbset.OrderBy(orderSelector).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum).ToListAsync(cancellationToken);
            }
            else
            {
                result = await dbset.OrderByDescending(orderSelector).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum).ToListAsync(cancellationToken); ;
            }
            var count = await GetCountAsync(cancellationToken);

            return new PagingQueryResult<IEnumerable<TAggregateRoot>>(queryModel.PageIndex, count, result.ToList());
        }
    }
}
