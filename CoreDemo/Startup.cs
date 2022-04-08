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
        public void ConfigureServices(IServiceCollection services) //yapýlandýrma servisi (hizmetleri)
        {      
            services.AddControllersWithViews().AddFluentValidation();//fluentvalidation kullanýma açtým
            services.AddTransient<IValidator, WriterValidator>(); //bll katmanýnda olan fluentvalidation dahil edildi
            services.AddTransient<IValidator, BlogValidator>();
            services.AddScobeBLL(); //BLL Katmanýnda dependencyInjection prensibi için oluþturduðum method dahil edildi.


            services.AddSession();
            services.AddMvc(config =>
            {
                //Proje seviyesinde zorunlu Authorize yaptýk..(bkz45) Rollere ve yetkiye göre sayfalara reaksiyon gösterecek. (Admin-writer-vsvs)
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //kullanýcýnýn sisteme Authentica olmasýný inþaa ettim..
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            
            services.AddMvc(); //tanýmlý olan methodu kullan için yazýldý..
            //services.AddSession(options =>
            //{
            //    //kullanýcý bilgilerini saklama cookiesi oluþturuldu.
            //    options.IdleTimeout = TimeSpan.FromSeconds(5);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;                

            //});
            //Proje seviyesinde kullanýcý yetkisi dýþýnda bir sayafaya gitmek istiyorsa ve bizde bunun önüne geçtiysek. kullanýcýya önce login ol yetki sýnýrýný göredlim dedim.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a => a.LoginPath = new PathString("/Account/Login"));

            services.ConfigureApplicationCookie(options =>
            {
                //Kullanýcý giriþ kayýtlarýný tutma hizmeti
                //Cookie settings AddSession alternatif ileride deðiþtirebilirim 45-50 
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(1);
                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
            });

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
            app.UseSession(); //Autantication iþlemleri yönlendirme ve cookie tanýmlamalarý için kullan..

           
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");  //Durum sayfasý hata aldýðýmýzda yönlenecek sayfa tanýmlamasý. Proje içinde gelen sayfayý kullanmayarak kendi oluþturðum hata sayfasýnýn tanýmlamasýný ve yolunu burada yaptým..
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //wwwroot ve static dosyalarý aktif etmek için tanýmlanýr.          
            app.UseRouting(); //route url         
            app.UseAuthentication();//Authentica olmamýmýzý saðlar. (login-register) controller action 
            app.UseAuthorization();//Admin Areas [Authorize] yetkilendir gibi iþlemler için controllerde vermiþ olduðumuz yetkilendirme iþlemlerini takip eder.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
