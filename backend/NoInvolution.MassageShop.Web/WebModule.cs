using MiCake.AspNetCore.Modules;
using MiCake.Core.Modularity;

namespace NoInvolution.MassageShop.Web
{
    [RelyOn(typeof(MiCakeAspNetCoreModule))]
    public class WebModule : MiCakeModule
    {
    }
}
