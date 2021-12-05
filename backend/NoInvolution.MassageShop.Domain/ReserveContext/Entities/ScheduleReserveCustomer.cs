using MiCake.DDD.Domain;

namespace NoInvolution.MassageShop.Domain.ReserveContext
{
    /// <summary>
    /// 预定某场按摩的客户
    /// </summary>
    public class ScheduleReserveCustomer : Entity
    {
        /// <summary>
        /// 顾客ID
        /// </summary>
        public int CustomerId { get; private set; }

        /// <summary>
        /// 预计到店时间
        /// </summary>
        public DateTime EstimatedArrivalTime { get; private set; }

        /// <summary>
        /// 预定时间（下单时间）
        /// </summary>
        public DateTime ReserveTime { get; private set; }

        public static ScheduleReserveCustomer Create(int customerId, DateTime estimatedTime)
        {
            if (customerId < 0)
            {
                throw DomainExceptionDescriber.DataError(nameof(customerId));
            }

            return new ScheduleReserveCustomer
            {
                CustomerId = customerId,
                EstimatedArrivalTime = estimatedTime,
                ReserveTime = DateTime.Now
            };
        }

        public void ChangeEstimateArrivalTime(DateTime time)
        {
            ReserveTime = time;
        }
    }
}
