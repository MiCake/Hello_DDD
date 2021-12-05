using MiCake.AspNetCore.Modules;
using MiCake.AutoMapper;
using MiCake.Core.Modularity;
using NoInvolution.MassageShop.EntityFramework;

namespace NoInvolution.MassageShop.Web
{
    [RelyOn(typeof(MassageEFCoreModule), typeof(MiCakeAspNetCoreModule), typeof(MiCakeAutoMapperModule))]
    [UseAutoMapper]
    public class WebModule : MiCakeModule
    {
    }
}
