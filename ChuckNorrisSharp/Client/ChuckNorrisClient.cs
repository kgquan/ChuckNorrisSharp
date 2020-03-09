using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChuckNorrisSharp.Client
{
    /// <summary>
    /// Client that retrieves the JSON data from api.chucknorris.io.
    /// </summary>
    class ChuckNorrisClient : IDisposable
    {
        private static HttpClient client;
        private CancellationTokenSource source;
        private CancellationToken cancellationToken;

        private const string BaseUrl = "https://api.chucknorris.io/";

        public ChuckNorrisClient()
        {
            client = new HttpClient();
            source = new CancellationTokenSource();
            cancellationToken = source.Token;
        }

        /// <summary>
        /// Releases this resource from memory (implements IDisposable).
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Asynchronously retrieves the JSON data from the specified URL.
        /// </summary>
        /// <typeparam name="T">A generic type.</typeparam>
        /// <param name="url">The string URL.</param>
        /// <returns>The task representing the work to be done.</returns>
        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.ffffff" } );
                        }
                    else
                    {
                        throw new Exception($"Response was not successful - error code {response.StatusCode}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HttpRequestException: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Async get failed: {ex.Message}", ex);
            }
        }
    }
}
