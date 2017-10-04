using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using travels.notifications;
using travels.services.service;
using travels.templates;

namespace travels.service.api.Config
{
    public class AutofacConfig
    {
        public static void Init(IAppBuilder app, HttpConfiguration httpConfig)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EmailNotification>().As<CloudNotification>().InstancePerRequest();
            

            // Services     
            builder.RegisterAssemblyTypes(typeof(EmailService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerRequest();


            builder.Register(c => new EmailTemplates()).InstancePerRequest();

            // builder.Register(c => new MemberService()).As<IMemberService>().InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(httpConfig);



            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            //app.UseAutofacLifetimeScopeInjector(container);       
            app.UseAutofacWebApi(httpConfig);
        }
    }
}