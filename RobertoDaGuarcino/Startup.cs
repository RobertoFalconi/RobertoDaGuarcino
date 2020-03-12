using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RobertoDaGuarcino
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Powered-By", "Microsoft");
                    context.Response.Headers.Add("Server", "Microsoft");
                    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    context.Response.Headers.Add("Content-Security-Policy", "base-uri 'none'; script-src 'self'; object-src 'self'");
                    context.Response.Headers.Add("Referrer-Policy", "same-origin");
                    context.Response.Headers.Add("Feature-Policy", "geolocation 'self'; midi 'self'; notifications 'self'; push 'self'; sync-xhr 'self'; microphone 'self'; camera 'self'; magnetometer 'self'; gyroscope 'self'; speaker 'self'; vibrate 'self'; fullscreen 'self'; payment 'self';");
                    return Task.CompletedTask;
                });
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
