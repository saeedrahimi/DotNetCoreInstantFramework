using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Web.Framework;

namespace WebPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .SeedData();
    }
}
