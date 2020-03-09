using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChuckNorrisSharp.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

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
        /// <returns>A generic object containing the deserialized JSON.</returns>
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
                        throw new ApiException($"Response was not successful - error code {response.StatusCode}");
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

        /// <summary>
        /// Asynchronously retrieves search results from the specified URL.
        /// </summary>
        /// <typeparam name="T">A generic type.</typeparam>
        /// <param name="url">The string URL.</param>
        /// <returns>A list of generic objects containing the deserialized JSON.</returns>
        public async Task<List<T>> GetAsyncSearchResults<T>(string url)
        {
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject searchResultsFromJson = JObject.Parse(json);

                        //The returned JSON should have two keys: a "total" key with the value of the number of jokes returned, 
                        //and a "result" key containing all of the jokes. A design decision was made to abstract the "total" out, 
                        //as users can use List<T>.Count() to get the number of jokes instead.
                        IList<JToken> results = searchResultsFromJson["result"].Children().ToList();
                        List<T> finalResult = new List<T>();
                        foreach(JToken result in results)
                        {
                            T searchResult = result.ToObject<T>();
                            finalResult.Add(searchResult);
                        }

                        return finalResult;
                    }
                    else
                    {
                        throw new ApiException($"Response was not successful - error code {response.StatusCode}");
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
