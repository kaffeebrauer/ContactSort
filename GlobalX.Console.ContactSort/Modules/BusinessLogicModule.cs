using Autofac;
using GlobalX.Console.ContactSort.BusinessLogic.Contact;
using GlobalX.Console.ContactSort.BusinessLogic.File;

namespace GlobalX.Console.ContactSort.Modules
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ContactBusinessLogic>()
               .As<IContactBusinessLogic>()
               .InstancePerLifetimeScope();

            builder.RegisterType<FileBusinessLogic>()
               .As<IFileBusinessLogic>()
               .InstancePerLifetimeScope();
        }
    }
}
