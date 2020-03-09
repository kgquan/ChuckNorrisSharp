using ChuckNorrisSharp.Client;
using ChuckNorrisSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChuckNorrisSharp
{
    /// <summary>
    /// The main wrapper class for the chucknorris.io API.
    /// </summary>
    public class ChuckNorrisApi : IDisposable
    {
        private ChuckNorrisClient client;
        /// <summary>
        /// The API URL.
        /// </summary>
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

        /// <summary>
        /// Gets a random Chuck Norris joke from the API.
        /// </summary>
        /// <returns>A Joke object representing a random joke.</returns>
        public async Task<Joke> GetRandomJoke()
        {
            string url = $"{BaseUrl}/jokes/random";

            return await client.GetAsync<Joke>(url);
        }

        /// <summary>
        /// Gets a random Chuck Norris joke from a specified set of categories.
        /// </summary>
        /// <param name="categories">A string array of potential categories to search in.</param>
        /// <returns>A Joke object containing a random joke from one of the specified categories.</returns>
        public async Task<Joke> GetRandomJoke(string[] categories)
        {
            string categoryString = String.Join(",", categories);

            string url = $"{BaseUrl}/jokes/random?category={categoryString}";

            return await client.GetAsync<Joke>(url);
        }

        /// <summary>
        /// Gets a random Chuck Norris joke, but personalizes the joke by switching out Chuck's name for a name 
        /// that you specify, e.g. Peter.
        /// </summary>
        /// <param name="name">The name that you want to replace Chuck Norris' name with.</param>
        /// <returns>A Joke object containing a random personalized joke.</returns>
        public async Task<Joke> GetRandomJoke(string name)
        {
            string url = $"{BaseUrl}/jokes/random?name={name}";

            return await client.GetAsync<Joke>(url);
        }

        /// <summary>
        /// Gets a random personalized Chuck Norris joke from a specified set of categories.
        /// </summary>
        /// <param name="name">The name that you want to replace Chuck Norris' name with.</param>
        /// <param name="categories">A string array of potential categories to search in.</param>
        /// <returns>A Joke object containing a random personalized joke from one of the specified categories.</returns>
        public async Task<Joke> GetRandomJoke(string name, string[] categories)
        {
            string categoryString = String.Join(",", categories);

            string url = $"{BaseUrl}/jokes/random?name={name}&category={categoryString}";

            return await client.GetAsync<Joke>(url);
        }

        /// <summary>
        /// Returns an array of categories that jokes can be filed under.
        /// </summary>
        /// <returns>A string array containing all of the catgories.</returns>
        public async Task<string[]> GetCategories()
        {
            string url = $"{BaseUrl}/jokes/categories";
            return await client.GetAsync<string[]>(url);
        }

        /// <summary>
        /// Returns all jokes containing the text specified.
        /// </summary>
        /// <param name="query">The text that you want to search for.</param>
        /// <returns>A List of Joke objects containing the search query in its text.</returns>
        public async Task<List<Joke>> SearchForText(string query)
        {
            string url = $"{BaseUrl}/jokes/search?query={query}";
            var response = await client.GetAsyncSearchResults<Joke>(url);

            return response;
        }
    }
}
