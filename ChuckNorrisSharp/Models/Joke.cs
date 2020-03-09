using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorrisSharp.Models
{
    /// <summary>
    /// Represents a Chuck Norris factoid.
    /// </summary>
    public class Joke
    {
        /// <summary>
        /// The list of categories the joke falls under.
        /// </summary>
        public List<object> Categories { get; set; }
        /// <summary>
        /// The DateTime of when the joke was first saved to the api.chucknorris.io database.
        /// </summary>
        [JsonProperty("Created_At")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The URL to the chucknorris.io icon. Used primarily for phone apps and chatbots.
        /// </summary>
        [JsonProperty("Icon_Url")]
        public string IconUrl { get; set; 
        /// <summary>
        /// The ID of the joke.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The DateTime the joke was last updated.
        /// </summary>
        [JsonProperty("Updated_At")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// The URL pointing to where you can read the joke for yourself on api.chucknorris.io.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The text containing the joke.
        /// </summary>
        public string Value { get; set; }
    }
}
