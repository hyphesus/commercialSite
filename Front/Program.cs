using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace YourProjectNamespace
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    namespace YourProjectNamespace
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                CreateHostBuilder(args).Build().Run();
            }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }
    }
}
//de�i�iklik3