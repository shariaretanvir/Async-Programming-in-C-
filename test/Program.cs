using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Given a sentence, reverse the word sequence and return the new sentence.
            ///// E.g. "Today, I am very happy!" =>"happy, very am I Today!"

            //string input = "Today, I am very happy";
            //string[] splitedArray = input.Split(" ");

            //Threads/Async-Await demo

            Console.Write("You want Sync or Async?");
            string value = Console.ReadLine();
            if (value == "Async") {
                Console.WriteLine("Will show you now");
                //GetDataFromAPIAsync();
            }
            else
            {
                DateTime startTime = DateTime.Now;
                dynamic finalApiData = await GetDataFromAPI();
                //Thread thread = Thread.CurrentThread;
                //Console.WriteLine("Main Current threadID {0}, thread pool {1}",thread.ManagedThreadId,thread.IsThreadPoolThread);
                //await GetDataFromAPI();
                Console.WriteLine("Final Data : {0}, {1}", finalApiData.data1, finalApiData.data2);
                Console.WriteLine("Total Time taken for those request : "+ DateTime.Now.Subtract(startTime));

            }

        }

        public static async Task<dynamic> GetDataFromAPI() {
            dynamic data = null;
            dynamic data1 =  GetAllCityPopulation();
            dynamic data2 =  GetAllCountryPopulation();
            //Thread thread = Thread.CurrentThread;
            //Console.WriteLine("After API Function Current threadID {0}, thread pool {1}", thread.ManagedThreadId, thread.IsThreadPoolThread);
            //GetAllCityPopulation();
            //GetAllCityPopulation();
            //GetAllCityPopulation();
            //GetAllCityPopulation();
            data = new
            {
                data1 = await data1,
                data2 = await data2
            };
            return data;
        }

        public static async Task<dynamic> GetAllCityPopulation() {
            dynamic data = null;
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            //Thread thread = Thread.CurrentThread;
            //Console.WriteLine("Before API Current threadID {0}, thread pool {1}", thread.ManagedThreadId, thread.IsThreadPoolThread);
            DateTime time = DateTime.Now;
            HttpResponseMessage response = await client.GetAsync("https://countriesnow.space/api/v0.1/countries/population/cities");
            if (response.IsSuccessStatusCode) {
                data = "City population Success";
            }
            Console.WriteLine("City population time taken : {0}", DateTime.Now.Subtract(time));
            //var d = await JsonSerializer.DeserializeAsync<dynamic>(await apiData);
            //Thread thread1 = Thread.CurrentThread;
            //Console.WriteLine("After API Current threadID {0}, thread pool {1}", thread1.ManagedThreadId, thread1.IsThreadPoolThread);
            return data;
        }
        public static async Task<dynamic> GetAllCountryPopulation()
        {
            dynamic data = null;
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            //Thread thread = Thread.CurrentThread;
            //Console.WriteLine("Before API Current threadID {0}, thread pool {1}", thread.ManagedThreadId, thread.IsThreadPoolThread);
            DateTime time = DateTime.Now;

            HttpResponseMessage response = await client.GetAsync("https://countriesnow.space/api/v0.1/countries/population");
            if (response.IsSuccessStatusCode)
            {
                data = "Country Population Success";
            }
            Console.WriteLine("Country population time taken : {0}", DateTime.Now.Subtract(time));
            //var d = await JsonSerializer.DeserializeAsync<dynamic>(await apiData);
            //Thread thread1 = Thread.CurrentThread;
            //Console.WriteLine("After API Current threadID {0}, thread pool {1}", thread1.ManagedThreadId, thread1.IsThreadPoolThread);
            return data;
        }
    }
}
