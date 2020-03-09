using System;
using System.Collections;
using System.Collections.Generic;
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
            ChuckNorrisApi api = new ChuckNorrisApi();

            try
            {
                Console.WriteLine("Getting random joke:");
                Joke joke = await api.GetRandomJoke();
                PrintProperties<Joke>(joke);

                Console.WriteLine("Getting random joke from a set of categories:");
                Joke jokeFromCategory = await api.GetRandomJoke(new string[] { "dev", "music" });
                PrintProperties<Joke>(jokeFromCategory);

                Console.WriteLine("Getting random personalized joke:");
                Joke personalizedJoke = await api.GetRandomJoke("Peter");
                PrintProperties<Joke>(personalizedJoke);

                Console.WriteLine("Getting random personalized joke from a set of categories:");
                Joke personalizedJokeFromCategory = await api.GetRandomJoke("Peter", new string[] { "dev", "music" });
                PrintProperties<Joke>(personalizedJokeFromCategory);

                Console.WriteLine("Getting categories:");
                string[] categories = await api.GetCategories();
                Console.WriteLine(string.Join(",", categories));

                Console.WriteLine("Getting all jokes containing a particular word or phrase:");
                List<Joke> searchResults = await api.SearchForText("films");
                foreach(Joke result in searchResults)
                {
                    PrintProperties<Joke>(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            api.Dispose();
        }

        /// <summary>
        /// Prints the properties of an element.
        /// </summary>
        /// <typeparam name="T">The element whose properties need to be printed.</typeparam>
        /// <param name="elem">The element.</param>
        private static void PrintProperties<T>(T elem)
        {
            string listString;

            if (elem != null)
            {
                Console.WriteLine($"Element of type {typeof(T).Name} received.");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(elem))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(elem);

                    if(value.GetType() == typeof(List<object>)) {
                        listString = string.Join(",", (List<object>)value);
                        Console.WriteLine("{0}: {1}", name, listString);
                    } else
                    {
                        Console.WriteLine("{0}: {1}", name, value);
                    }
                }
            }
        }
    }
}
