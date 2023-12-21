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
<<<<<<< Updated upstream
}
=======
//de�i�iklik3
>>>>>>> Stashed changes
