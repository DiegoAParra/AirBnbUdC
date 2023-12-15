[assembly: WebActivator.PostApplicationStartMethod(typeof(AirBnbUdC.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace AirBnbUdC.GUI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using AirbnbUdc.Application.Implementation.Implementation.Parameters;
    using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
    using AirbnbUdc.Repository.Implementation.Implementation.Parameters;
    using AirbnbUdC.Application.Contracts.Contracts.Parameters;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ICountryRepository, CountryImplementationRepository>(Lifestyle.Scoped);
            container.Register<ICountryApplication, CountryImplementationApplication>(Lifestyle.Scoped);
            container.Register<ICityRepository, CityImplementationRepository>(Lifestyle.Scoped);
            container.Register<ICityApplication, CityImplementationApplication>(Lifestyle.Scoped);
            container.Register<ICustomerRepository, CustomerImplementationRepository>(Lifestyle.Scoped);
            container.Register<ICustomerApplication, CustomerImplementationApplication>(Lifestyle.Scoped);
            container.Register<IMultimediaTypeRepository, MultimediaTypeImplementationRepository>(Lifestyle.Scoped);
            container.Register<IMultimediaTypeApplication, MultimediaTypeImplementationApplication>(Lifestyle.Scoped);
            container.Register<IPropertyRepository, PropertyImplementationRepository>(Lifestyle.Scoped);
            container.Register<IPropertyApplication, PropertyImplementationApplication>(Lifestyle.Scoped);
            container.Register<IPropertyMultimediaRepository, PropertyMultimediaImplementationRepository>(Lifestyle.Scoped);
            container.Register<IPropertyMultimediaApplication, PropertyMultimediaImplementationApplication>(Lifestyle.Scoped);
            container.Register<IPropertyOwnerRepository, PropertyOwnerImplementationRepository>(Lifestyle.Scoped);
            container.Register<IPropertyOwnerApplication, PropertyOwnerImplementationApplication>(Lifestyle.Scoped);
            container.RegisterMvcControllers();
        }
    }
}