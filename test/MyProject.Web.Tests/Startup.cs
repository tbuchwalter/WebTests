using System;
using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProject.Authentication.JwtBearer;
using MyProject.Configuration;
using MyProject.EntityFrameworkCore;
using MyProject.Identity;
using MyProject.Web.Resources;
using MyProject.Web.Startup;

namespace MyProject.Web.Tests
{
    public class Startup { 

    private readonly IConfigurationRoot _appConfiguration;
    public Startup(IHostingEnvironment env)
    {
    _appConfiguration = env.GetAppConfiguration();
    }
    
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase();

            services.AddMvc();
            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);


            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

            //Configure Abp and Dependency Injection
            return services.AddAbp<MyProjectWebTestModule>(options =>
            {
                options.SetupTest();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            UseInMemoryDb(app.ApplicationServices);

            app.UseAbp(); //Initializes ABP framework.

            app.UseExceptionHandler("/Error");

            app.UseAuthentication();

            app.UseMiddleware<TestAuthenticationMiddleware>();
            app.UseJwtTokenMiddleware();


            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }

        private void UseInMemoryDb(IServiceProvider serviceProvider)
        {
            var builder = new DbContextOptionsBuilder<MyProjectDbContext>();
            //var optiosn = SqliteInMemory.CreateOptions<AllPointsDbContext>();
            //var connencionStringBuilder
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);
            var options = builder.Options;

            var iocManager = serviceProvider.GetRequiredService<IIocManager>();

            iocManager.IocContainer
                .Register(
                    Component.For<DbContextOptions<MyProjectDbContext>>()
                    .Instance(options)
                    .LifestyleSingleton()
                );
        }
    }
}