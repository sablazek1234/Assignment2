using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace APISelfhosted
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up server configuration

            Uri _baseAddress = new Uri("http://localhost:60000/");

            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);

            config.Routes.MapHttpRoute(

            name: "DefaultApi",

            routeTemplate: "api/{controller}/{action}/{id}",

            defaults: new { id = RouteParameter.Optional }

            );

            // Create server

            HttpSelfHostServer server = new HttpSelfHostServer(config);

            // Start listening

            server.OpenAsync().Wait();

            Console.WriteLine("Products Web-API Self hosted on " + _baseAddress);

            Console.WriteLine("Press ENTER to exit...");

            Console.ReadLine();

            server.CloseAsync().Wait();
        }
    }
}
