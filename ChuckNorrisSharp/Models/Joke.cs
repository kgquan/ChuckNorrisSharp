using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorrisSharp.Models
{
    /// <summary>
    /// Represents a Chuck Norris factoid.
    /// </summary>
    class Joke
    {
        public List<object> Categories { get; set; }
        public string CreatedAt { get; set; }
        public string IconUrl { get; set; }
        public string Id { get; set; }
        public string UpdatedAt { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
