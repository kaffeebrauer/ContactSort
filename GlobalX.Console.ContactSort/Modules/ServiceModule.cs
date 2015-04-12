using Autofac;
using GlobalX.Console.ContactSort.Services;

namespace GlobalX.Console.ContactSort.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<FileService>()
               .As<IFileService>()
               .SingleInstance();

            builder.RegisterType<ContactService>()
               .As<IContactService>()
               .SingleInstance();
        }
    }
}
