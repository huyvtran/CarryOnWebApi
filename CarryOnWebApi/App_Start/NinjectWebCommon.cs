[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarryOnWebApi.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CarryOnWebApi.NinjectWebCommon), "Stop")]

namespace CarryOnWebApi
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Ninject.Web.WebApi;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Services;
    using DAL;
    using Services.Interfaces;
    using System.Web.Configuration;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["Mock"]) ||
                (WebConfigurationManager.AppSettings["Mock"].ToLower() != "true"))
            {
                kernel.Bind<IReqGoodTransferService>().To<ReqGoodTransferService>();
                kernel.Bind<IDalManager>().To<DalManager>();
                kernel.Bind<IConfigurationProvider>().To<Configuration>();
                kernel.Bind<ILogService>().To<Log4NetLogService>();
            }
            else {
                kernel.Bind<IReqGoodTransferService>().To<ReqGoodTransferService>();
                /* Mock */
                kernel.Bind<IDalManager>().To<DalManagerMock>();
                kernel.Bind<IConfigurationProvider>().To<Configuration>();
                kernel.Bind<ILogService>().To<Log4NetLogService>();
            };
        }        
    }
}
