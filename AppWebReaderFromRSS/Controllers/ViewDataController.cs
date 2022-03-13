using AppWebReaderFromRSS.BD.Context;
using AppWebReaderFromRSS.BD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebReaderFromRSS.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class ViewDataController : Controller
	{
		private const int WidthStep = 10;
		private readonly NewsBDContext BDContext;

		public ViewDataController(NewsBDContext bDContext)
		{
			BDContext = bDContext;
		}

		[HttpGet]
		public async Task<IEnumerable<string>> GetSourсes()
			=> (await BDContext.NewsSourсes.ToListAsync()).Select(x => x.Sourсe);

		[HttpPost]
		public async Task<int> GetNumberStep(ArgumentClass argumentClass)
		{
			string source = argumentClass.source;
			IEnumerable<News> newsCollection = await BDContext.News.ToListAsync();

			bool isNotEmptySource = !String.IsNullOrWhiteSpace(source);
			if (isNotEmptySource)
			{
				newsCollection = newsCollection.Where(news => news.NewsSourсeId == source);
			}

			double steps = (double)newsCollection.Count() / WidthStep;
			return (int)Math.Ceiling(steps);
		}

		[HttpPost]
		public IEnumerable<News> GetNewsCollectionByParametr(ArgumentClass argumentClass)
		{
			IEnumerable<News> newsCollection = BDContext.News.ToList();
			string source = argumentClass.source;
			string orderBy = argumentClass.orderBy;
			int step = argumentClass.step;

			bool isNotEmptySource = !String.IsNullOrWhiteSpace(source);
			if (isNotEmptySource)
			{
				newsCollection = newsCollection.Where(news => news.NewsSourсeId == source);
			}

			if (orderBy == "date")
			{
				newsCollection = newsCollection.OrderByDescending(news => news.PublicationDate);
			}
			else if (orderBy == "sourse")
			{
				newsCollection = newsCollection.OrderBy(news => news.NewsSourсeId);
			}

			return newsCollection.Skip(WidthStep * step).Take(WidthStep);
		}

		public class ArgumentClass
		{
			public string source { get; set; }
			public string orderBy { get; set; }
			public int step { get; set; }
		}

	}
}
