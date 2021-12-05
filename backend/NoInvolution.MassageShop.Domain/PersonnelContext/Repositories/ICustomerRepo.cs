using NoInvolution.MassageShop.Domain.Common;

namespace NoInvolution.MassageShop.Domain.PersonnelContext
{
    public interface ICustomerRepo : ISearchShortInfoRepository<Customer, Customer, int>
    {
    }
}
