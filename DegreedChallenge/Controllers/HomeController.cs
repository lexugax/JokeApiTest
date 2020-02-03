using DegreedChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DegreedChallenge.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// Index page.
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Random joke page. Shows one joke every 10 seconds.
		/// </summary>
		/// <returns></returns>
		public IActionResult Random()
		{
			return View();
		}

		/// <summary>
		/// Search joke page. Lets you search for jokes which contain a keyword.
		/// </summary>
		/// <returns></returns>
		public IActionResult Search()
		{
			return View();
		}
		
		/// <summary>
		/// Returns a random joke as a json object.
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Returns the result of a joke search as a json object.
		/// </summary>
		/// <param name="searchTerm">Keywork to search in jokes.</param>
		/// <param name="page">Page to return if more than one page available.</param>
		/// <returns></returns>
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
