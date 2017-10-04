using Microsoft.Owin;
using travels.service.api.Config;
using Owin;
using System.Web.Http;
using travels.service.api;
using System.Web.Http.ExceptionHandling;
using System.IO;
using System.Reflection;
using travels.templates;

[assembly: OwinStartup(typeof(Startup))]

namespace travels.service.api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {           
            // Code that runs on application startup
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            HttpConfiguration httpConfig = new HttpConfiguration();

            httpConfig.Services.Replace(typeof(IExceptionHandler), new ErrorHandlingMiddleware());

            AutoMapperConfig.Init();

            AutofacConfig.Init(app, httpConfig);

            //TemplateConfiguration.Init();

            //ConfigureOAuth(app);

            WebApiConfig.Register(httpConfig);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            app.UseWebApi(httpConfig);


        }


        /*private void ConfigureOAuth(IAppBuilder app)
        {
            //Token Consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
            });
        }*/
    }
}