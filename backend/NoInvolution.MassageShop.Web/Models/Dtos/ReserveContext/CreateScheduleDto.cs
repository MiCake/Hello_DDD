namespace NoInvolution.MassageShop.Web.Models.Dtos.ReserveContext
{
    public class CreateScheduleDto
    {
        public int TeachnicianId { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }
    }
}
