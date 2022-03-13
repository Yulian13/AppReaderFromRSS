using AppWebReaderFromRSS.BD.Context;
using AppWebReaderFromRSS.BD.Models;
using AppWebReaderFromRSS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AppWebReaderFromRSS.Controllers
{
	public class HomeController : Controller
	{
		private readonly NewsBDContext BDContext;

		public HomeController(NewsBDContext bDContext)
		{
			BDContext = bDContext;
		}

		public IActionResult NewsBelt()
		{
			IEnumerable<string> sources = BDContext.NewsSourсes.Select(x => x.Sourсe);
			return View(sources);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
