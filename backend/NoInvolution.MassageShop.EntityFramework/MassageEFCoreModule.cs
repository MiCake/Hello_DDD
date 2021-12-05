using MiCake.Core.Modularity;
using NoInvolution.MassageShop.Domain;

namespace NoInvolution.MassageShop.EntityFramework
{
    [RelyOn(typeof(MassageDomainModule))]
    public class MassageEFCoreModule : MiCakeModule
    {
        public override void ConfigServices(ModuleConfigServiceContext context)
        {
            // customer repositories
            context.AutoRegisterRepositories(typeof(MassageEFCoreModule).Assembly, (repo, repoInterface, index) =>
            {
                return repoInterface.Name.Contains(repo.Name);
            });
        }
    }
}
