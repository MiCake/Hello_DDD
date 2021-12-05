using MiCake.Audit;
using MiCake.DDD.Domain;
using MiCake.DDD.Extensions.LinqFilter;
using MiCake.DDD.Extensions.LinqFilter.Extensions;
using MiCake.DDD.Extensions.Paging;
using Microsoft.EntityFrameworkCore;
using NoInvolution.MassageShop.Domain.Common;
using System.Linq.Expressions;

namespace NoInvolution.MassageShop.EntityFramework.Core
{
    /// <summary>
    /// 具有分页查找和搜索功能的仓储
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TShortInfo"></typeparam>
    /// <typeparam name="TAggregateRoot"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    internal abstract class SearchShortInfoEFRepository<TDbContext, TShortInfo, TAggregateRoot, TKey> : PagingEFRepository<TDbContext, TAggregateRoot, TKey>, ISearchShortInfoRepository<TShortInfo, TAggregateRoot, TKey>
          where TDbContext : DbContext
          where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        protected SearchShortInfoEFRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IEnumerable<TShortInfo>> FindList(IEnumerable<TKey> ids, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);
            return await dbset.Where(s => ids.Contains(s.Id)).Select(SelectedShortInfo).ToListAsync(cancellationToken);
        }

        public async Task<TShortInfo> FindWithShortInfo(TKey id, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);
            return await dbset.Where(s => s.Id.Equals(id)).Select(SelectedShortInfo).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PagingQueryResult<IEnumerable<TShortInfo>>> PagingQueryShortInfoAsync(PagingQueryModel queryModel, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);

            var count = await GetCountAsync(cancellationToken);

            if (count <= 0)
            {
                return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, 0, null);
            }

            IEnumerable<TShortInfo> result;
            if (typeof(IHasCreationTime).IsAssignableFrom(typeof(TAggregateRoot)))
            {
                result = await dbset.OrderBy(s => ((IHasCreationTime)s).CreationTime).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum)
                                    .Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }
            else
            {
                result = await dbset.Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum).Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }

            return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, count, result.ToList());
        }

        public async Task<PagingQueryResult<IEnumerable<TShortInfo>>> PagingQueryShortInfoAsync<TOrderKey>(PagingQueryModel queryModel, Expression<Func<TAggregateRoot, TOrderKey>> orderSelector, bool asc = true, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);

            var count = await GetCountAsync(cancellationToken);

            if (count <= 0)
            {
                return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, 0, null);
            }

            IEnumerable<TShortInfo> result;
            if (asc)
            {
                result = await dbset.OrderBy(orderSelector).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum)
                                    .Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }
            else
            {
                result = await dbset.OrderByDescending(orderSelector).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum)
                                    .Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }


            return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, count, result.ToList());
        }

        public async Task<PagingQueryResult<IEnumerable<TShortInfo>>> Search(List<Filter> filters, PagingQueryModel queryModel, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);

            var filterLambda = filters.GetFilterExpression<TAggregateRoot>();

            var count = await dbset.CountAsync(filterLambda, cancellationToken);

            if (count <= 0)
            {
                return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, 0, null);
            }

            IEnumerable<TShortInfo> result;
            if (typeof(IHasCreationTime).IsAssignableFrom(typeof(TAggregateRoot)))
            {
                result = await dbset.Where(filterLambda).OrderBy(s => ((IHasCreationTime)s).CreationTime).Page(queryModel.PageIndex, queryModel.PageNum)
                                    .Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }
            else
            {
                result = await dbset.Where(filterLambda).Page(queryModel.PageIndex, queryModel.PageNum).Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }


            return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, count, result);
        }

        public async Task<PagingQueryResult<IEnumerable<TShortInfo>>> Search<TOrderKey>(List<Filter> filters, PagingQueryModel queryModel, Expression<Func<TAggregateRoot, TOrderKey>> orderSelector, bool asc = true, CancellationToken cancellationToken = default)
        {
            var dbset = await GetDbSetAsync(cancellationToken);

            IEnumerable<TShortInfo> result;
            var filterLambda = filters.GetFilterExpression<TAggregateRoot>();

            var count = await dbset.CountAsync(filterLambda, cancellationToken);

            if (count <= 0)
            {
                return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, 0, null);
            }

            if (asc)
            {
                result = await dbset.Where(filterLambda).OrderBy(orderSelector).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum)
                                    .Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }
            else
            {
                result = await dbset.Where(filterLambda).OrderByDescending(orderSelector).Skip(queryModel.CurrentStartNo).Take(queryModel.PageNum)
                                    .Select(SelectedShortInfo).ToListAsync(cancellationToken);
            }

            return new PagingQueryResult<IEnumerable<TShortInfo>>(queryModel.PageIndex, count, result);
        }

        public abstract Expression<Func<TAggregateRoot, TShortInfo>> SelectedShortInfo { get; }
    }
}
