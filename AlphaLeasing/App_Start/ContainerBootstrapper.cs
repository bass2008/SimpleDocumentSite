using System;
using AlphaLeasing.DataAccess.Configuration;
using AlphaLeasing.DataAccess.Repository;
using AlphaLeasing.DataAccess.UnitOfWork;
using AlphaLeasing.Mapping;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NHibernate;

namespace AlphaLeasing.App_Start
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        private readonly IWindsorContainer container;

        ContainerBootstrapper(IWindsorContainer container)
        {
            this.container = container;
        }

        public IWindsorContainer Container
        {
            get { return container; }
        }
        
        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().
                Install(FromAssembly.This());

            container.Register(Component.For<IDocumentMapper>().ImplementedBy<DocumentMapper>());

            
            //container.AddFacility<FactorySupportFacility>();
            container.Register(Component.For<ISessionFactory>()
                                   .UsingFactoryMethod(() => NHibernateConfiguration.CreateSessionFactory()));

            container.Register(Component.For<ISession>()
                                   .UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>().OpenSession())
                                   .LifestylePerWebRequest());
            
            container.Register(Component.For<ITransaction>()
                                   .UsingFactoryMethod(kernel => kernel.Resolve<ISession>().BeginTransaction())
                                   .LifestylePerWebRequest());

            container.Register(Component.For(typeof(IRepository<>))
                                   .ImplementedBy(typeof(GenericRepository<>))
                                   .LifeStyle.Transient);

            container.Register(Component.For<IUnitOfWork>()
                       .ImplementedBy<UnitOfWork>()
                       .LifeStyle.Transient);

            return new ContainerBootstrapper(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}