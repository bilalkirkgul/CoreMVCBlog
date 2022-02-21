using BLL.Concrete.DependencyInjection;
using BLL.ValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) //yapýlandýrma servisi
        {      
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator, WriterValidator>(); //fluentvalidation
            services.AddScobeBLL(); 
            //services.AddSession();
            services.AddMvc(config =>
            {
                //Proje seviyesinde Authorize yaptýk..(bkz45) Rollere göre sayfalara geçilecek
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;


            });


            //kullanýcý yetkisi dýþýnda bir sayafaya gitmek istiyorsa ve bizde bunun önüne geçtiysek. kullanýcýya önce login ol yetki sýnýrýný göredlim dedim.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a => a.LoginPath = new PathString("/Login/Index"));

            //services.ConfigureApplicationCookie(options =>
            //{

            //    //Cookie settings AddSession alternatif
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            //    options.LoginPath = "/Login/Index";
            //    options.SlidingExpiration = true;
            //});

        }
      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");              
                app.UseHsts();
            }
            app.UseSession(); //Autantication iþlemleri yönlendirme ve cookie

            //Durum sayfasý hata aldýðýmýzda yönlenecek.
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //wwwroot
            app.UseAuthentication();
            app.UseRouting(); //route url         
            app.UseAuthentication();//yetkili olduðumuzu takip eder..
            app.UseAuthorization();//Admin Areas  [Authorize] yetkilendir gibi iþlemler için kullanýlýr.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
