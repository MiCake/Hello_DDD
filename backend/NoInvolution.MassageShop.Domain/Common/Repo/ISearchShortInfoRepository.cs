using MiCake.DDD.Domain;
using MiCake.DDD.Extensions.LinqFilter;
using MiCake.DDD.Extensions.Paging;
using System.Linq.Expressions;

namespace NoInvolution.MassageShop.Domain.Common
{
    public interface ISearchShortInfoRepository<TShortInfo, TAggregateRoot, TKey> : IPagingRepository<TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        Task<PagingQueryResult<IEnumerable<TShortInfo>>> PagingQueryShortInfoAsync(PagingQueryModel queryModel, CancellationToken cancellationToken = default);

        Task<PagingQueryResult<IEnumerable<TShortInfo>>> PagingQueryShortInfoAsync<TOrderKey>(PagingQueryModel queryModel, Expression<Func<TAggregateRoot, TOrderKey>> orderSelector, bool asc = true, CancellationToken cancellationToken = default);

        Task<TShortInfo> FindWithShortInfo(TKey id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TShortInfo>> FindList(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);

        Task<PagingQueryResult<IEnumerable<TShortInfo>>> Search(List<Filter> filters, PagingQueryModel queryModel, CancellationToken cancellationToken = default);

        Task<PagingQueryResult<IEnumerable<TShortInfo>>> Search<TOrderKey>(List<Filter> filters, PagingQueryModel queryModel, Expression<Func<TAggregateRoot, TOrderKey>> orderSelector, bool asc = true, CancellationToken cancellationToken = default);
    }
}
