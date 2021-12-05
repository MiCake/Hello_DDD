using NoInvolution.MassageShop.Domain.Common;

namespace NoInvolution.MassageShop.Domain.ReserveContext
{
    public interface IMassageScheduleRepo : ISearchShortInfoRepository<MassageSchedule, MassageSchedule, int>
    {
        /// <summary>
        /// 获取某位技师某一天的排班
        /// </summary>
        /// <param name="technicianId"></param>
        /// <param name="Day"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<MassageSchedule>> GetTechnicianOneDaySchedule(int technicianId, DateTime Day, CancellationToken cancellationToken = default);
    }
}
