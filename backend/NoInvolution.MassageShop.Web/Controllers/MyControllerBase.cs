using AutoMapper;
using MiCake.Core.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace NoInvolution.MassageShop.Web.Controllers
{
    public class MyControllerBase : ControllerBase
    {
        public CancellationToken AbortedToken => HttpContext.RequestAborted;

        protected DreamControllerInfrastructure Infrastructure { get; }
        protected IMapper Mapper => Infrastructure.Mapper;
        protected ILoggerFactory LoggerFactory { get; set; }

        public MyControllerBase(DreamControllerInfrastructure infrastructure, ILoggerFactory loggerFactory)
        {
            Infrastructure = infrastructure;
            LoggerFactory = loggerFactory;
        }
    }

    [InjectService(typeof(DreamControllerInfrastructure), Lifetime = MiCakeServiceLifetime.Transient)]
    public class DreamControllerInfrastructure
    {
        public IMapper Mapper { get; set; }

        public DreamControllerInfrastructure(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
