using MiCake;
using MiCake.Core.Handlers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NoInvolution.MassageShop.EntityFramework;

namespace NoInvolution.MassageShop.Web
{
    public static class RegisterMiCakeServiceExtension
    {
        public static void AddMiCakeServices(this WebApplicationBuilder webBuilder)
        {
            webBuilder.Services.TryAddSingleton<ExceptionLoggerHandler>();
            webBuilder.Services.AddMiCakeWithDefault<WebModule, MassageDbContext>(
                miCakeConfig: options =>
                {
                    options.Handlers.Add<ExceptionLoggerHandler>();     // 添加全局异常日志拦截器
                },
                miCakeAspNetConfig: options =>
                {
                    options.DataWrapperOptions.IsDebug = webBuilder.Environment.IsDevelopment();
                })
                .Build();
        }
    }

    internal class ExceptionLoggerHandler : IMiCakeExceptionHandler
    {
        private readonly ILogger<ExceptionLoggerHandler> _logger;

        public ExceptionLoggerHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ExceptionLoggerHandler>();
        }

        public Task Handle(MiCakeExceptionContext exceptionContext, CancellationToken cancellationToken = default)
        {
            if (exceptionContext.Exception != null)
                _logger.LogError(exceptionContext.Exception, exceptionContext.Exception.Message);

            return Task.CompletedTask;
        }
    }
}
