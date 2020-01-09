using System;
using Nancy;
using Nancy.Hosting.Self;

namespace CSHARP_REST_API
{
  class Program
  {
    static void Main(string[] args)
    {
      HostConfiguration hostConfigs = new HostConfiguration();
      hostConfigs.UrlReservations.CreateAutomatically = true;
      hostConfigs.RewriteLocalhost = false;

      var PORT = Environment.GetEnvironmentVariable("PORT") ?? "5000";
      using (var host = new NancyHost(hostConfigs, new Uri("http://localhost:" + PORT)))
      {
        host.Start();
        Console.WriteLine("NancyFX Stand alone test application.");
        Console.WriteLine("Enter 'q' to exit the application");
        while (Console.ReadLine() != "q") ;
        host.Stop();
      }
    }
  }

  public class HelloModule : NancyModule
  {
    public HelloModule()
    {
      Get("/hello", _ => "world of csharp");
    }
  }
}
