using DegreedChallenge.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace DegreedChallenge
{
    public class JokeApplicationServices
    {
        private const string _baseAddress = "https://icanhazdadjoke.com/";
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Gets a random joke from the joke api.
        /// </summary>
        /// <returns></returns>
        public async Task<JokeModel> GetRandomJoke()
        {
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Task<Stream> stringTask = _client.GetStreamAsync(_baseAddress);

                JokeModel joke = await JsonSerializer.DeserializeAsync<JokeModel>(await stringTask);

                return joke;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Searches for jokes that contain the specified term.
        /// </summary>
        /// <param name="term">Keywork to find in jokes.</param>
        /// <param name="page">Results page when more than one page is available.</param>
        /// <returns></returns>
        public async Task<JokeSearchResultsModel> SearchJokes(string term, int page = 1)
        {
            try
            {
                string uri = $"{_baseAddress}search?term={term}&page={page}&limit=30";

                if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                {
                    _client.DefaultRequestHeaders.Accept.Clear();
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Task<Stream> stringTask = _client.GetStreamAsync(uri);

                    JokeSearchResultsModel results = await JsonSerializer.DeserializeAsync<JokeSearchResultsModel>(await stringTask);

                    return results;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
