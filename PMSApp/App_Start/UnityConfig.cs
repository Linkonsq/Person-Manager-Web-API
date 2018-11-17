using System.Web.Http;
using Unity;
using Unity.WebApi;
using PMSInterface;
using PMSRepository;

namespace PMSApp
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();
			
			// register all your components with the container here
			// it is NOT necessary to register your controllers
			
			// e.g. container.RegisterType<ITestService, TestService>();

			container.RegisterType<ICategoryRepository, CategoryRepository>();
			container.RegisterType<IProductRepository, ProductRepository>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}