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
  /bin
  /obj/Debug
  .DS_STORE
  ```

# To Deploy REST API via Heroku

- **Step 1**: Since Heroku generally sets its own port and host, we need to change the program to get the port and host from environment variables. So in _Program.cs_ inside Main() function, add and change the following:-

  ```c#
  // ...
  String PORT = Environment.GetEnvironmentVariable("PORT");
  String HOST = Environment.GetEnvironmentVariable("HOST");
  using (var host = new NancyHost(hostConfigs, new Uri("http://" + HOST + ":" + PORT)))
  // ...
  ```

- **Step 2**: Now create a folder _.github/workflows_ and in there create a file _main.yml_ with contents:

  ```yaml
  name: Deploy
  on:
    push:
      branches:
        - master
  jobs:
    build:
      runs-on: ubuntu-latest

      steps:
        - uses: actions/checkout@v1.0.0
        - uses: akhileshns/heroku-deploy@master
          with:
            heroku_api_key: ${{secrets.HEROKU_API_KEY}}
            heroku_email: ${{secrets.HEROKU_EMAIL}}
            heroku_app_name: ${{secrets.HEROKU_APP_NAME}}
            buildpack: 'https://github.com/heroku/dotnet-buildpack.git'
  ```

- **Step 3**: Now we can push this to GitHub but before that, make sure you have created a Heroku account and in account settings, copy the api key. Then in the github repo for this project, go to settings and add secrets HEROKU_API_KEY (Your copied apikey), HEROKU EMAIL (The email associated with your heroku account) and HEROKU_APP_NAME (The name of your app and keep in mind it needs to be unique in heroku)

  Now whenever you push to the master branch of your github repo, your app is automatically deployed to heroku
