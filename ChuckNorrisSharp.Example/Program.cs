using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ChuckNorrisSharp;
using ChuckNorrisSharp.Models;

namespace ChuckNorrisSharp.Example
{
    class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {
            Console.WriteLine("Getting joke:");
            ChuckNorrisApi api = new ChuckNorrisApi();

            try
            {

                Joke joke = await api.GetRandomJoke();

                if (joke != null)
                {
                    Console.WriteLine("Joke received.");
                    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(joke))
                    {
                        string name = descriptor.Name;
                        object value = descriptor.GetValue(joke);
                        Console.WriteLine("{0}: {1}", name, value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }



            api.Dispose();
        }
    }
}
