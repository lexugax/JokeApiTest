using DegreedChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DegreedChallenge.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

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

			return Json(joke);
		}

		public async Task<IActionResult> SearchJokes(string searchTerm, int page = 1)
		{
			JokeApplicationServices jokeApi = new JokeApplicationServices();
			JokeSearchResultsModel searchResults = await jokeApi.SearchJokes(searchTerm, page);

			return Json(searchResults);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
