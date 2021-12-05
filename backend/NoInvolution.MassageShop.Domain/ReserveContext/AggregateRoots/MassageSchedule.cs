using MiCake.DDD.Domain;
using NoInvolution.MassageShop.Domain.Common;

namespace NoInvolution.MassageShop.Domain.ReserveContext
{
    /// <summary>
    /// 按摩排班信息
    /// </summary>
    public class MassageSchedule : AuditAggregateRoot
    {
        /// <summary>
        /// 所关联的技师ID
        /// </summary>
        public int TechnicianId { get; set; }

        /// <summary>
        /// 排班（上班）时间
        /// </summary>
        public ScheduleTimeRange WorkTime { get; set; }

        /// <summary>
        /// 当前的预定客户
        /// </summary>
        public ScheduleReserveCustomer? ReserveCustomer { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ScheduleState State { get; private set; }

        public static MassageSchedule Create(int teachnicianId, DateTime startTime, DateTime endTime)
        {
            return new MassageSchedule
            {
                TechnicianId = teachnicianId,
                WorkTime = ScheduleTimeRange.Create(startTime, endTime),
                State = ScheduleState.Open
            };
        }

        /// <summary>
        /// 接受预定
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="arrivalTime"></param>
        public void ReceiveReserve(int customerId, DateTime arrivalTime)
        {
            ReserveCustomer = ScheduleReserveCustomer.Create(customerId, arrivalTime);

            CloseReserve();
        }

        /// <summary>
        /// 取消预定
        /// </summary>
        public void CancelReserve()
        {
            ReserveCustomer = null;

            OpenReserve();
        }

        /// <summary>
        /// 变更预约顾客的到店时间
        /// </summary>
        /// <param name="arrivalTime"></param>
        /// <exception cref="DomainException"></exception>
        public void ChangeReserveCustomerArrivalTime(DateTime arrivalTime)
        {
            if (ReserveCustomer == null)
            {
                throw new DomainException("当前的排班还没有被预定");
            }

            ReserveCustomer.ChangeEstimateArrivalTime(arrivalTime);
        }

        /// <summary>
        /// 关闭预定
        /// </summary>
        public void CloseReserve()
        {
            State = ScheduleState.Close;
        }

        /// <summary>
        /// 开放预定
        /// </summary>
        public void OpenReserve()
        {
            State = ScheduleState.Open;
        }
    }
}
