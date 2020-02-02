using System.Text.Json.Serialization;

namespace DegreedChallenge.Models
{
    public class JokeModel
    {
        //"id": "R7UfaahVfFd",
        //"joke": "My dog used to chase people on a bike a lot. It got so bad I had to take his bike away.",
        //"status": 200

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("joke")]
        public string Joke { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
