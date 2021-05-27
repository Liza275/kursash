using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SchoolBusinessLogic.ViewModel;

namespace SchoolEmployeeWebApp
{
    public class Program
    {
        public static EmployeeViewModel Employee { get; set; }
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
