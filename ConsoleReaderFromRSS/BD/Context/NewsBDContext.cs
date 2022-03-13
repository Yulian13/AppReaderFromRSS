using ConsoleReaderFromRSS.BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace ConsoleReaderFromRSS.BD.Context
{
	class NewsBDContext : DbContext
	{
		public DbSet<News> News { get; set; }
		public DbSet<NewsSourсe> NewsSourсes { get; set; }

		public NewsBDContext()
		{
			Database.EnsureCreated();

			News.Load();
			NewsSourсes.Load();
		}

		public void InitSources(IEnumerable<string> sources)
		{
			foreach (string source in sources)
			{
				if (NewsSourсes.Find(source) == null)
				{
					var newSource = new NewsSourсe(source);
					NewsSourсes.Add(newSource);
				}
			}
		}

		public int AddNewsCollection(List<News> newsCollection)
		{
			int countAdded = 0;

			foreach (News news in newsCollection)
			{
				if (News.Find(news.UrlLink) == null)
				{
					News.Add(news);
					countAdded++;
				}
			}

			return countAdded;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connection = GetConnectionString();
			optionsBuilder.UseSqlServer(connection);
		}

		private string GetConnectionString()
			=> new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build()
				.GetConnectionString("NewsBD");
	}
}
