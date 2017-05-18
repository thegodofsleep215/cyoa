using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cyoaCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseUrl = "http://+:80/";

            using (WebApp.Start<ApiStartup>(baseUrl))
            {
                Console.WriteLine("Press any key to stop.");
                Console.ReadKey();
                Console.WriteLine("Stopped.");

            }
        }
    }
}
