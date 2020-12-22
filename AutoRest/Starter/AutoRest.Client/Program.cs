using System;
using Autorest.Sdk;
using Autorest.Sdk.Models;
using System.Collections.Generic;
using static System.Console;

namespace Autorest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyAPI client = new MyAPI(new Uri("http://localhost:5000"));
            IList<Destination> destinationList = client.ApiDestinationsGet();

            WriteLine("\nAll Destination");
            foreach (Destination destination in destinationList)
            {
                WriteLine($"{destination.CityName} - {destination.Airport}");
            }
            // ReadKey used that the console will not close when the code end to run.
            ReadKey();
        }
    }
}
