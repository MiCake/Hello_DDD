using Microsoft.AspNetCore.Mvc;
using NoInvolution.MassageShop.Domain.ReserveContext;
using NoInvolution.MassageShop.Web.Models.Dtos;
using NoInvolution.MassageShop.Web.Models.Dtos.ReserveContext;

namespace NoInvolution.MassageShop.Web.Controllers.ReserveContext
{
    [Route("api/v1/reserve-api/schedules")]
    [ApiController]
    public class MassageScheduleController : MyControllerBase
    {
        private readonly IMassageScheduleRepo _repo;

        public MassageScheduleController(
            IMassageScheduleRepo repo,
            DreamControllerInfrastructure infrastructure,
                                         ILoggerFactory loggerFactory) : base(infrastructure, loggerFactory)
        {
            _repo = repo;
        }

        [HttpGet("{id:int}")]
        public async Task<MassageScheduleDto> Get(int id)
        {
            var result = await _repo.FindAsync(id, AbortedToken);
            return Mapper.Map<MassageScheduleDto>(result);
        }

        [HttpGet("teachnicians/{teachnicianId:int}")]
        public async Task<List<MassageScheduleDto>> GetWithTeachnicianAndDay(int teachnicianId, DateTimeOffset day)
        {
            var result = await _repo.GetTechnicianOneDaySchedule(teachnicianId, day.LocalDateTime, AbortedToken);
            return Mapper.Map<List<MassageScheduleDto>>(result);
        }

        [HttpPost]
        public async Task<bool> CreateNewSchedule([FromBody] CreateScheduleDto data)
        {
            var schedule = MassageSchedule.Create(data.TeachnicianId, data.StartTime.LocalDateTime, data.EndTime.LocalDateTime);
            await _repo.AddAsync(schedule, AbortedToken);

            return true;
        }

        [HttpPost("{id:int}/reserve")]
        public async Task<bool> ReserveCurrentSchedule(int id, [FromBody] ReserveScheduleDto data)
        {
            var schedule = await GetScheduleWithEmptyError(id);

            schedule.ReceiveReserve(data.CustomerId, data.ArrivalTime?.LocalDateTime ?? schedule.WorkTime.StartTime);
            return true;
        }


        [HttpDelete("{id:int}/reserve")]
        public async Task<bool> CancelReserveCurrentSchedule(int id)
        {
            var schedule = await GetScheduleWithEmptyError(id);

            schedule.CancelReserve();
            return true;
        }

        [HttpPut("{id:int}/reserve/arrivaltime")]
        public async Task<bool> ChangeReserveScheduleArrivalTime(int id, [FromBody] SimpleDto<DateTimeOffset> data)
        {
            var schedule = await GetScheduleWithEmptyError(id);

            schedule.ChangeReserveCustomerArrivalTime(data.Data.LocalDateTime);
            return true;
        }

        private async Task<MassageSchedule> GetScheduleWithEmptyError(int id)
        {
            var result = await _repo.FindAsync(id, AbortedToken);

            if (result == null)
            {
                throw new ArgumentException("未找到对应的排班");
            }

            return result;
        }
    }
}
