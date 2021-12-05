using MiCake.AspNetCore.Modules;
using MiCake.Core.Modularity;
using MiCake.EntityFrameworkCore.Modules;

namespace NoInvolution.MassageShop.Web
{
    [RelyOn(typeof(MiCakeEFCoreModule), typeof(MiCakeAspNetCoreModule))]
    public class WebModule : MiCakeModule
    {
    }
}
