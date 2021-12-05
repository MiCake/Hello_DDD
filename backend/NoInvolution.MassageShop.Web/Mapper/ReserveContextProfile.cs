using AutoMapper;
using NoInvolution.MassageShop.Domain.ReserveContext;
using NoInvolution.MassageShop.Web.Models.Dtos.ReserveContext;

namespace NoInvolution.MassageShop.Web.Mapper
{
    public class ReserveContextProfile : Profile
    {
        public ReserveContextProfile()
        {
            CreateMap<MassageSchedule, MassageScheduleDto>()
                .ForMember(s => s.StartTime, opt => opt.MapFrom(j => j.WorkTime.StartTime))
                .ForMember(s => s.EndTime, opt => opt.MapFrom(j => j.WorkTime.EndTime));
        }
    }
}
