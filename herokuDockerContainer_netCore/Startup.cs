using herokuDockerContainer_netCore.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace herokuDockerContainer_netCore
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
            var conStr = "server=45.132.242.151;port=3306;database=test;user=root;password=!PRG48yJArmM3qOy";
            services.AddControllersWithViews();
            //services.AddDbContext<EFContext>(options => options.UseMySql("server=klbcedmmqp7w17ik.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;database=a679vilqt4awm293;user=nzyotqeclxf5vpld;password=xz7q354ompilvzj2", new MySqlServerVersion(new Version(8, 0, 11))));
            Console.WriteLine("Using: " + conStr);
            services.AddDbContext<EFContext>(options => options.UseMySql(conStr, new MySqlServerVersion(new Version(8, 0, 11))));

            //services.AddDbContext<EFContext>(options => options.UseMySql("server=192.168.1.74;port=3306;database=EFCoreMySQL;user=root;password=123456", new MySqlServerVersion(new Version(8, 0, 11))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EFContext _context)
        {
            _context.Database.Migrate();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
