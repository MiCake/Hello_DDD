namespace NoInvolution.MassageShop.Infrastructure.Date
{
    public class SystemClock
    {
        public static DateTime Now
        {
            get => DateTimeOffset.UtcNow.UtcDateTime;
        }
    }
}
