using MiCake.AspNetCore.Modules;
using MiCake.AutoMapper;
using MiCake.Core.Modularity;
using MiCake.EntityFrameworkCore.Modules;

namespace NoInvolution.MassageShop.Web
{
    [RelyOn(typeof(MiCakeEFCoreModule), typeof(MiCakeAspNetCoreModule))]
    [UseAutoMapper]
    public class WebModule : MiCakeModule
    {
    }
}
