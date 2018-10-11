using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using LoveTheCoffeeHouse.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoveTheCoffeeHouse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies
                // is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register Services
            //container.Register<IMyService>(() => new LazyServiceProxy(
            //    new Lazy<IMyService>(container.GetInstance<RealService>)));

            // You can't directly register an IUrlHelper in the DI container.
            // Resolving an instance of IUrlHelper requires you to use the IUrlHelperFactory
            // and IActionContextAccessor. 

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddScoped<IUrlHelper>(x => x
                    .GetRequiredService<IUrlHelperFactory>()
                    .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void RegisterServices(IApplicationBuilder app, IHostingEnvironment env)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
           // UrlHelperExtensions.Configure(httpContextAccessor);
        }
    }
}
