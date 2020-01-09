# JS REST API

- **Step 1**: To install .NET Core run

  - windows - `choco install dotnetcore-sdk -y`
  - macos - `brew cask install dotnet-sdk`
  - linux - `sudo snap install dotnet-sdk --classic && sudo snap alias dotnet-sdk.dotnet dotnet`

  [OR] Download and install it from [here](https://dotnet.microsoft.com/download)

  Verify everything is installed using `dotnet --version`

- **Step 2**: Create a new folder, open a bash/powershell/cmd window inside the folder and run `dotnet new console`

- **Step 3**: Then run the commands `dotnet add package Nancy` amd `dotnet add package Nancy.Hosting.Self`

- **Step 4**: In the same folder, go to _Program.cs_ and fill it with the following contents:-

  ```c#
  using System;
  /*Add this*/
  using Nancy;
  using Nancy.Hosting.Self;
  /**/

  namespace CSHARP_REST_API
  {
    class Program
    {
      static void Main(string[] args)
      {
        /*Add this*/
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
        /**/
      }
    }

    /*Add this*/
    public class HelloModule : NancyModule
    {
      public HelloModule()
      {
        Get("/hello", _ => "world of c#");
      }
    }
    /**/
  }
  ```

- **Step 5**: Finally run `dotnet run` to launch your REST API

- **Step 6**: **Step 6**: Don't forget to add a _.gitignore_ file and use git to manage your project. The contents of the _.gitignore_ file are:-
  ```
  .DS_STORE
  ```
