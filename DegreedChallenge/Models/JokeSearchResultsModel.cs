using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DegreedChallenge.Models
{
	public class JokeSearchResultsModel
    {
		//"current_page": 1,
		//"limit": 20,
		//"next_page": 2,
		//"previous_page": 1,
		//"results": [
		//    {
		//        "id": "M7wPC5wPKBd",
		//        "joke": "Did you hear the one about the guy with the broken hearing aid? Neither did he."
		//    },
		//    {
		//        "id": "MRZ0LJtHQCd",
		//        "joke": "What do you call a fly without wings? A walk."
		//    },
		//    {
		//        "id": "usrcaMuszd",
		//        "joke": "What's the worst thing about ancient history class? The teachers tend to Babylon."
		//    }
		//],
		//"search_term": "",
		//"status": 200,
		//"total_jokes": 307,
		//"total_pages": 15

		[JsonPropertyName("current_page")]
		public int Page { get; set; }

		[JsonPropertyName("limit")]
		public int JokesPerPage { get; set; }

		[JsonPropertyName("next_page")]
		public int NextPage { get; set; }

		[JsonPropertyName("previous_page")]
		public int PreviousPage { get; set; }

		[JsonPropertyName("results")]
		public List<JokeModel> Results { get; set; }

		[JsonPropertyName("search_term")]
		public string SearchTerm { get; set; }

		[JsonPropertyName("status")]
		public int Status { get; set; }

		[JsonPropertyName("total_jokes")]
		public int TotalJokes { get; set; }

		[JsonPropertyName("total_pages")]
		public int TotalPages { get; set; }
	}
}
