using Contact.Api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost().Run();
    }

    public static IWebHost BuildWebHost() => WebHost.CreateDefaultBuilder()
        .UseStartup<Startup>().Build();
}