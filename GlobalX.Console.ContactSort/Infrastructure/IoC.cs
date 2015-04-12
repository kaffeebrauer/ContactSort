using Autofac;
using GlobalX.Console.ContactSort.BusinessLogic.Core;
using GlobalX.Console.ContactSort.Modules;

namespace GlobalX.Console.ContactSort.Infrastructure
{
    public static class IoC
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(Program).Assembly);
            builder.RegisterModule<MainModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<LoggingModule>();
            builder.RegisterModule<BusinessLogicModule>();
            builder.RegisterAssemblyTypes(typeof(ContactModelFactory).Assembly)
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(ContactModelFactory).Assembly)
                .AsClosedTypesOf(typeof(ModelFactory<>))
                .InstancePerLifetimeScope();

            var container = builder.Build();
            return container;
        }
    }
}
