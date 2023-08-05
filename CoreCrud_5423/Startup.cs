using CoreCrud_5423.Infrastructure.Concrete;
using CoreCrud_5423.Infrastructure.Interfaces.Concrete;
using CoreCrud_5423.Models.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423
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

            services.AddDbContext<ProjectContext>(opt=> 
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
                opt.UseLazyLoadingProxies(true);
            });


            services.AddScoped<IDirector, DirectorRepo>();
            services.AddScoped<IActorRepo, ActorRepo>();
            services.AddScoped<IMovieRepo, MovieRepo>();

            //services.AddTransient => Her istekte bulunduğunda nesneyi oluşturur ve sornasında h dispose eder her talepte yeni nesne oluşturur
           // services.AddScoped => Her istek geldiğinde nesneyi oluşturur ancan Transientten farklı olarak hala nesne kullanımdayken yeni bir talep gelirse nesne oluşturmaz elindeki nesneyi kullandırır
           // services.AddSingleton => Her istenen nesneden bir kez oluşturur, ve çağrıldığında hep aynı nesneyi verir
           

            // Todo: addscoped - addtransient - addsingleton : gömülü metotlarını bir araştırın.

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
            }
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
