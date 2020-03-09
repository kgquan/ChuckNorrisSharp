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
        public List<object> Categories { get; set; }
        [JsonProperty("Created_At")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("Icon_Url")]
        public string IconUrl { get; set; }
        public string Id { get; set; }
        [JsonProperty("Updated_At")]
        public DateTime UpdatedAt { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
