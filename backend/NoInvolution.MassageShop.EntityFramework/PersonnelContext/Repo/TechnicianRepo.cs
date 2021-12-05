using NoInvolution.MassageShop.Domain.PersonnelContext;
using NoInvolution.MassageShop.EntityFramework.Core;
using System.Linq.Expressions;

namespace NoInvolution.MassageShop.EntityFramework.PersonnelContext
{
    internal class TechnicianRepo : SearchShortInfoEFRepository<MassageDbContext, Technician, Technician, int>, ITechnicianRepo
    {
        public TechnicianRepo(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Expression<Func<Technician, Technician>> SelectedShortInfo => s => s;
    }
}
