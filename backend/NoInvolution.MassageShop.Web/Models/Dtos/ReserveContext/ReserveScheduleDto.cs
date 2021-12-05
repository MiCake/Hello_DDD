namespace NoInvolution.MassageShop.Web.Models.Dtos.ReserveContext
{
    public class ReserveScheduleDto
    {
        public int CustomerId { get; set; }

        public DateTimeOffset? ArrivalTime { get; set; }
    }
}
