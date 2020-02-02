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

        public async Task<JokeModel> GetRandomJoke()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Degreed challenge"));
            
            Task<Stream> stringTask = _client.GetStreamAsync(_baseAddress);

            JokeModel joke = await JsonSerializer.DeserializeAsync<JokeModel>(await stringTask);

            return joke;
        }

        public async Task<JokeSearchResultsModel> SearchJokes(string term, int page = 1)
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
    }
}
