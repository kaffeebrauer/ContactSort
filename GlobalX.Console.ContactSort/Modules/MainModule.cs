using Autofac;
using GlobalX.Console.ContactSort.Application;
using GlobalX.Console.ContactSort.BusinessLogic.Infrastructure;

namespace GlobalX.Console.ContactSort.Modules
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ContactManager>()
                .As<IApplication>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MapperService>()
               .As<IMapperService>()
               .InstancePerLifetimeScope();

        }
    }
}
