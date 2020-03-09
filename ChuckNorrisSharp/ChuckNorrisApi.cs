using ChuckNorrisSharp.Client;
using ChuckNorrisSharp.Models;
using System;
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
    }
}
