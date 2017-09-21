using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.ServiceLocation.Compatibility;
using EPiStarterSite.Features.Shared.Models;

namespace EPiStarterSite.Infrastructure.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitializationcs : IConfigurableModule
    {

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure(c =>
            {
                c.For<LayoutModel>().HybridHttpOrThreadLocalScoped().Use<LayoutModel>();
            });
        }

        public void Initialize(InitializationEngine context)
        {
            //Add initialization logic, this method is called once after CMS has been initialized
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}