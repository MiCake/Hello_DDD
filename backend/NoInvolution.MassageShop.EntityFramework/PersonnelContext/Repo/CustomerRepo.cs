using NoInvolution.MassageShop.Domain.PersonnelContext;
using NoInvolution.MassageShop.EntityFramework.Core;
using System.Linq.Expressions;

namespace NoInvolution.MassageShop.EntityFramework.PersonnelContext
{
    internal class CustomerRepo : SearchShortInfoEFRepository<MassageDbContext, Customer, Customer, int>, ICustomerRepo
    {
        public CustomerRepo(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Expression<Func<Customer, Customer>> SelectedShortInfo => s => s;
    }
}
