using ChuckNorrisSharp.Client;
using ChuckNorrisSharp.Models;
using System;
using System.Threading.Tasks;

namespace ChuckNorrisSharp
{
    public class ChuckNorrisApi : IDisposable
    {
        private ChuckNorrisClient client;

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
            string url = "https://api.chucknorris.io/jokes/random";

            return await client.GetAsync<Joke>(url);
        }
    }
}
