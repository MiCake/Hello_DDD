using NoInvolution.MassageShop.Domain.ReserveContext;
using NoInvolution.MassageShop.EntityFramework.Core;
using NoInvolution.MassageShop.Infrastructure.Date;
using System.Linq.Expressions;

namespace NoInvolution.MassageShop.EntityFramework.ReserveContext
{
    internal class MassageScheduleRepo : SearchShortInfoEFRepository<MassageDbContext, MassageSchedule, MassageSchedule, int>, IMassageScheduleRepo
    {
        public MassageScheduleRepo(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Expression<Func<MassageSchedule, MassageSchedule>> SelectedShortInfo => s => s;

        public async Task<List<MassageSchedule>> GetTechnicianOneDaySchedule(int technicianId, DateTime Day, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync(cancellationToken);

            var dayStart = DateTimeHelper.GetDayStartTime(Day);
            var dayEnd = DateTimeHelper.GetDayEndTime(Day);

            var result = dbSet.Where(s => s.TechnicianId == technicianId && s.WorkTime.StartTime >= dayStart && s.WorkTime.EndTime <= dayEnd);
            return result.ToList();
        }
    }
}
