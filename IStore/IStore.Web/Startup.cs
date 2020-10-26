using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
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
            var connString = Configuration.GetConnectionString("Default");

            builder.RegisterType<CategoriesRepository>().As<IRepository<Category>>()
                .WithParameter(new TypedParameter(typeof(string), connString))
                .SingleInstance();

            builder.RegisterType<UsersRepository>().As<IUsersRepository>()
                .WithParameter(new TypedParameter(typeof(string), connString))
                .SingleInstance();

            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>()
                .WithParameter(new TypedParameter(typeof(string), connString))
                .SingleInstance();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("Default");

            services.AddControllersWithViews(x => x.Filters.Add(new AuthorizeFilter()));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
                //.AddCookie(x=>x.LoginPath = "Account/SignIn");

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
