using Microsoft.EntityFrameworkCore;
using NoInvolution.MassageShop.Domain.ReserveContext;

namespace NoInvolution.MassageShop.EntityFramework.ReserveContext
{
    internal static class ReserveContextModelBuilderExtension
    {
        public static ModelBuilder AddReserveContextModel(this ModelBuilder builder)
        {
            builder.Entity<MassageSchedule>(s =>
            {
                s.OwnsOne(j => j.WorkTime);
            });

            builder.Entity<ScheduleReserveCustomer>(s =>
            {
                s.HasIndex(j => j.CustomerId);
            });

            return builder;
        }
    }
}
