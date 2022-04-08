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
        public void ConfigureServices(IServiceCollection services) //yap�land�rma servisi (hizmetleri)
        {      
            services.AddControllersWithViews().AddFluentValidation();//fluentvalidation kullan�ma a�t�m
            services.AddTransient<IValidator, WriterValidator>(); //bll katman�nda olan fluentvalidation dahil edildi
            services.AddTransient<IValidator, BlogValidator>();
            services.AddScobeBLL(); //BLL Katman�nda dependencyInjection prensibi i�in olu�turdu�um method dahil edildi.


            services.AddSession();
            services.AddMvc(config =>
            {
                //Proje seviyesinde zorunlu Authorize yapt�k..(bkz45) Rollere ve yetkiye g�re sayfalara reaksiyon g�sterecek. (Admin-writer-vsvs)
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //kullan�c�n�n sisteme Authentica olmas�n� in�aa ettim..
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            
            services.AddMvc(); //tan�ml� olan methodu kullan i�in yaz�ld�..
            //services.AddSession(options =>
            //{
            //    //kullan�c� bilgilerini saklama cookiesi olu�turuldu.
            //    options.IdleTimeout = TimeSpan.FromSeconds(5);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;                

            //});
            //Proje seviyesinde kullan�c� yetkisi d���nda bir sayafaya gitmek istiyorsa ve bizde bunun �n�ne ge�tiysek. kullan�c�ya �nce login ol yetki s�n�r�n� g�redlim dedim.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a => a.LoginPath = new PathString("/Account/Login"));

            services.ConfigureApplicationCookie(options =>
            {
                //Kullan�c� giri� kay�tlar�n� tutma hizmeti
                //Cookie settings AddSession alternatif ileride de�i�tirebilirim 45-50 
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
            app.UseSession(); //Autantication i�lemleri y�nlendirme ve cookie tan�mlamalar� i�in kullan..

           
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");  //Durum sayfas� hata ald���m�zda y�nlenecek sayfa tan�mlamas�. Proje i�inde gelen sayfay� kullanmayarak kendi olu�tur�um hata sayfas�n�n tan�mlamas�n� ve yolunu burada yapt�m..
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //wwwroot ve static dosyalar� aktif etmek i�in tan�mlan�r.          
            app.UseRouting(); //route url         
            app.UseAuthentication();//Authentica olmam�m�z� sa�lar. (login-register) controller action 
            app.UseAuthorization();//Admin Areas [Authorize] yetkilendir gibi i�lemler i�in controllerde vermi� oldu�umuz yetkilendirme i�lemlerini takip eder.

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
