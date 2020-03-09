# ChuckNorrisSharp
An C# wrapper for https://api.chucknorris.io, a Chuck Norris joke API.

## Requirements
* .NET Standard 2.0
* Newtonsoft Json.NET (12.0.3)

## Installation instructions
Clone or download it from Github as a .zip file.
Build the library and add it to your application as a dependency.

## Usage
```csharp
using ChuckNorrisSharp;

ChuckNorrisApi api = new ChuckNorrisApi();

try {
  //Get a random joke
  Joke joke = await api.GetRandomJoke();
  
  //Get a random joke from a specified set of categories
  Joke jokeFromCategory = await api.GetRandomJoke(new string[] { "dev", "music" });
  
  //Get a random personalized joke
  Joke personalizedJoke = await api.GetRandomJoke("Jake");
  
  //Get a random personalized joke from a specified set of categories
  Joke personalizedJokeFromCategory = await api.GetRandomJoke("Jake", new string[] { "dev", "music" });
  
  //Get a list of categories
  string[] categories = await api.GetCategories();
  
  //Search and return a list of all jokes with a particular input word or phrase
  List<Joke> searchResults = await api.SearchForText("films");
  
} catch(Exception ex) {
  Console.WriteLine(ex);
}

api.Dispose();
```
## License
This repository is under the GNU General Public License v3.0.
