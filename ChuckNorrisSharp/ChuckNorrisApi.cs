using ChuckNorrisSharp.Client;
using ChuckNorrisSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChuckNorrisSharp
{
    public class ChuckNorrisApi : IDisposable
    {
        private ChuckNorrisClient client;
        private const string BaseUrl = "https://api.chucknorris.io";

        public ChuckNorrisApi()
        {
            client = new ChuckNorrisClient();
        }

        /// <summary>
        /// Releases this resource from memory (implements IDisposable).
        /// </summary>
        public void Dispose()
        {
            if(client != null)
            {
                client.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public async Task<Joke> GetRandomJoke()
        {
            string url = $"{BaseUrl}/jokes/random";

            return await client.GetAsync<Joke>(url);
        }

        public async Task<Joke> GetRandomJoke(string[] categories)
        {
            string categoryString = String.Join(",", categories);

            string url = $"{BaseUrl}/jokes/random?category={categoryString}";

            return await client.GetAsync<Joke>(url);
        }

        public async Task<Joke> GetRandomJoke(string name)
        {
            string url = $"{BaseUrl}/jokes/random?name={name}";

            return await client.GetAsync<Joke>(url);
        }

        public async Task<Joke> GetRandomJoke(string name, string[] categories)
        {
            string categoryString = String.Join(",", categories);

            string url = $"{BaseUrl}/jokes/random?name={name}&category={categoryString}";

            return await client.GetAsync<Joke>(url);
        }

        public async Task<string[]> GetCategories()
        {
            string url = $"{BaseUrl}/jokes/categories";
            return await client.GetAsync<string[]>(url);
        }

        public async Task<List<Joke>> SearchForText(string query)
        {
            string url = $"{BaseUrl}/jokes/search?query={query}";
            var response = await client.GetAsyncSearchResults<Joke>(url);

            return response;
        }
    }
}
