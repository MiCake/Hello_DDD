using MiCake;
using NoInvolution.MassageShop.EntityFramework;

namespace NoInvolution.MassageShop.Web
{
    public static class RegisterMiCakeServiceExtension
    {
        public static void AddMiCakeServices(this WebApplicationBuilder webBuilder)
        {
            webBuilder.Services.AddMiCakeWithDefault<WebModule, MassageDbContext>(

                miCakeAspNetConfig: options =>
                {
                    options.DataWrapperOptions.IsDebug = webBuilder.Environment.IsDevelopment();
                })
                .Build();
        }
    }
}
