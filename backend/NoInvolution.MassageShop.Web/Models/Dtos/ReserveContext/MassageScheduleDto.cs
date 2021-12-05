using NoInvolution.MassageShop.Domain.ReserveContext;

namespace NoInvolution.MassageShop.Web.Models.Dtos.ReserveContext
{
    public class MassageScheduleDto
    {
        public int Id { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public ScheduleState State { get; set; }
    }
}
