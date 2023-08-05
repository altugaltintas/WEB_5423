using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Intro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        /*
         StartUp sınıfı içindeki ConfigureServices metodu uygulamadaki hizmetleri yapılandırmak için bulunmaktadır. Çalışma zamanı çağırılan bu metot sayesinde uygulama içinde kullanılacak olan servisler tanıtılır ve bu servisler aracaılığıyla bağğımlılık ekleme (DI - Dependeny Injektion )  aracılığıyla tüketim yapılabilir.
        
        .NetCore uygulamalarındaki dışarıdan yüklenen paketler burada tanıtılabilir.
         
         */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /*
            Çalışma zamanı(runtime da) çağırılan bir diğer metot ise CONFIGURE metodudur. Gelen HTTP isteklerine ardışık düzeni yapılandırmamızı sağlar.

            Uygulama içinde kullanılan paket ayarları burada yapılabilir.

            IApplicationBuilder => interfacesi sayesinde uygulama ayağa kalkarken , uygulama runtimedayken uygulamaya müdahale edilebilir.    app. diyerek çalışacak servislerin konfigurasyonları yapılır.
        
            IWebHostEnvironment  => interfacesi sayesinde uygulamanın çalışacağı ortam , okuyacağımız env parametresi sayesinde test ortamı , geliştirme ortamı yada canlı ortam olduğu belirlenir.

            Uygulamadaki Middleware burada entegre edilir.
         */
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

            // wwwroot altındaki sabit dosyaları kullanmamızı sağlar.
            app.UseStaticFiles();

            //uygulama içinde isteğe bağlı olarak yapılan yönlendirme (route) varsa sorumlusu burasıdır.
            //uygulamada tanımlı endPoint(varsayılan route) bakarak yol tayin eder, en iyi eşleşmeyi yapar.
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // varsayılan olarak belirlenen route yani rota bilgisine sahiptir. 
                //Program ilk çalıştığınnda çalışan rota : localHost/Home/index/varsa paramatre yani home isimli controllerın altındaki index actionına gidilecek ve parametre opsiyonel olacak.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

               
                // istenirse farklı desen yada isimlerde rotaalar oluşturulabilir tabiki.
            });
        }
    }
}
