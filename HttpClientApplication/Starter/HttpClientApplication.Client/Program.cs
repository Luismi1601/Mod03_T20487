using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using HttpClientApplication.Host.Models;
using System.Runtime.Serialization.Json;
using static System.Console;

namespace HttpClientApplication.Client
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, clientCertificateOption,ContextMarshalException,sslPolicyErrors) => {return true;};
            
            using (var client = new HttpClient(clientHandler)) //= new HttpClientHandler(); 
            //clientHandler.ServerCertificateCustomValidationCallback))
            {
                HttpResponseMessage message = await client.GetAsync("https://localhost:5001/api/destinations");
                WriteLine("Respone data as string");
                string resultAsString = await message.Content.ReadAsStringAsync();
                WriteLine(resultAsString);
                
                List<Destination> destinationsResult = await message.Content.ReadAsAsync<List<Destination>>();
                WriteLine("\nAll Destination");
                foreach (Destination destination in destinationsResult)
                {
                    WriteLine($"{destination.CityName} - {destination.Airport}");
                }
                // ReadKey used that the console will not close when the code end to run.
                ReadKey();
            }
        }
    }
}
