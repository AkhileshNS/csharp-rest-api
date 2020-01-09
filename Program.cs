﻿using System;
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
      using (var host = new NancyHost(hostConfigs, new Uri("http://localhost:5000")))
      {
        host.Start();

        Console.WriteLine("NancyFX Stand alone test application.");
        Console.WriteLine("Press enter to exit the application");
        Console.ReadLine();
      }
    }
  }

  public class HelloModule : NancyModule
  {
    public HelloModule()
    {
      Get("/hello", _ => "world of c#");
    }
  }
}