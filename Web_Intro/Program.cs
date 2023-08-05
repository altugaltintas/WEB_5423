using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Intro
{
    public class Program
    {
        /*
            Programımızı default olarak ayağa kaldıran çalışan ilk metot MAIN metottur.
        .NETCORE ile birlike web uygulamaları artık her platformda çalışır hale geldi.
        Bu nedenle hangi ortamda çalışmak istersek buradaki  CreateHostBuilder() metodunu düzenleyerek  farklı serverlarda uygulamamızı ayağa kaldırabiliriz. Default olarak IIS (Internet Informatıon Server ) üzerinde çalışır. 
         
         */
        public static void Main(string[] args)
        {
            // MAIN içindeki bu metot sayesinde string argumanları alarak komutları çalıştırır.
            CreateHostBuilder(args).Build().Run();
        }

        // CreateHostBuilder() metoduna bakıldığında ise yapacağı işlemleri , okuyacağı konfigurasyonlar için STARTUP sınıfa gider ve oradaka kullanılan Configure Ve ConfigureServices metotlarındaki ayarları okuyarak uygulamaya ayağa kaldırır , build edilir ve çalıştırılır MAIN içinde.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
