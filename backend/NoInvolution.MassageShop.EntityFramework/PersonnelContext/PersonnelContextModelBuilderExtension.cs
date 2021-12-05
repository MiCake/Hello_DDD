using Microsoft.EntityFrameworkCore;
using NoInvolution.MassageShop.Domain.PersonnelContext;

namespace NoInvolution.MassageShop.EntityFramework
{
    internal static class PersonnelContextModelBuilderExtension
    {
        public static ModelBuilder AddPersonnelContextModel(this ModelBuilder builder)
        {
            builder.Entity<Technician>(s =>
            {
                s.OwnsOne(j => j.ContactInfo);
            });

            return builder;
        }
    }
}
