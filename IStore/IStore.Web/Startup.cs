using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using IStore.BusinessLogic.Services;
using IStore.BusinessLogic.Services.Interfaces;
using IStore.Data;
using IStore.Data.Interfaces;
using IStore.Data.Repositories;
using IStore.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IStore.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            RegisterDataAccess(builder);
        }

        private void RegisterDataAccess(ContainerBuilder builder)
        {
            var connectionString = Configuration.GetConnectionString("Default");

            #region IRepository<T> DI

            builder.RegisterType<CategoriesRepository>().As<ICategoriesRepository>()
                .WithParameter(new PositionalParameter(0, connectionString))
                .WithParameter(new PositionalParameter(1, "categories"))
                .SingleInstance();

            builder.RegisterType<UsersRepository>().As<IUsersRepository>()
                .WithParameter(new PositionalParameter(0, connectionString))
                .WithParameter(new PositionalParameter(1, "users"))
                .SingleInstance();

            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>()
                .WithParameter(new PositionalParameter(0, connectionString))
                .WithParameter(new PositionalParameter(1, "settings"))
                .SingleInstance();

            builder.RegisterType<ProductsRepository>().As<IProductsRepository>()
                .WithParameter(new PositionalParameter(0, connectionString))
                .WithParameter(new PositionalParameter(1, "products"))
                .SingleInstance();
            #endregion

            #region Services DI

            builder.RegisterType<UsersManagementService>().As<IUsersManagementService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            #endregion
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("Default");

            services.AddControllersWithViews(x => x.Filters.Add(new AuthorizeFilter()));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddOptions();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
