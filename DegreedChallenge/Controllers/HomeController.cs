using DegreedChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DegreedChallenge.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Random()
		{
			return View();
		}

		public IActionResult Search()
		{
			return View();
		}
		
		public async Task<IActionResult> GetRandomJoke()
		{
			JokeApplicationServices jokeApi = new JokeApplicationServices();
			JokeModel joke = await jokeApi.GetRandomJoke();

			if (joke != null)
			{
				return Json(joke);
			}

			return StatusCode(500);
		}

		public async Task<IActionResult> SearchJokes(string searchTerm, int page = 1)
		{
			JokeApplicationServices jokeApi = new JokeApplicationServices();
			JokeSearchResultsModel searchResults = await jokeApi.SearchJokes(searchTerm, page);

			if(searchResults != null)
			{
				return Json(searchResults);
			}

			return StatusCode(500);
		}		
	}
}
