using ConsoleReaderFromRSS.BD.Context;
using ConsoleReaderFromRSS.BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleReaderFromRSS.Controller
{
	class MonitoredConsole
	{
		private readonly List<PairComandaMethod> PairComandaMethodCollection;
		private readonly NewsBDContext DBContext;
		private readonly NewsManager NewsManager;

		public MonitoredConsole(NewsBDContext newsBDContext)
		{
			DBContext = newsBDContext;
			NewsManager = new NewsManager();

			PairComandaMethodCollection = GetInitPairComandaMethodCollection();
			PairComandaMethodCollection.ForEach(pair =>
				Console.WriteLine($"{pair.Comanda} - {pair.Description}")
			);
		}

		public void MonitorConsole()
		{
			do
			{
				try
				{
					string readString = Console.ReadLine();
					PairComandaMethod pair = PairComandaMethodCollection.First(pair => pair.Comanda.Equals(readString));
					pair.Method();
				}
				catch (CloseConsole)
				{
					break;
				}
				catch (InvalidOperationException)
				{
					Console.WriteLine("this command is not exist");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			} while (true);
		}

		private List<PairComandaMethod> GetInitPairComandaMethodCollection()
		{
			return new List<PairComandaMethod>() {
				new PairComandaMethod()
				{
					Comanda = "RS",
					Description = "Read and save latest news",
					Method = ReadAndSaveLatestNews
				},
				new PairComandaMethod()
				{
					Comanda = "CL",
					Description = "Close Console",
					Method = CloseConsole
				}
			};
		}

		private void CloseConsole()
			=> throw new CloseConsole();

		private void ReadAndSaveLatestNews()
		{
			InitSources();

			List<News> newsCollection = NewsManager.GetNewsCollection();
			IEnumerable<IGrouping<string, News>> soursCollections = newsCollection.GroupBy(x => x.NewsSourсeId);
			foreach (var group in soursCollections)
			{
				var newsList = group.ToList();
				int countAdded = DBContext.AddNewsCollection(newsList);

				Console.WriteLine($"{group.Key}: readed - {group.Count()}, Added - {countAdded}");
			}
			Console.WriteLine();

			DBContext.SaveChanges();
		}

		private void InitSources()
		{
			IEnumerable<string> sourсes = NewsManager.GetSourceCollection();
			DBContext.InitSources(sourсes);
			//DBContext.SaveChanges();
		}

		struct PairComandaMethod
		{
			public string Comanda;
			public string Description;
			public Action Method;
		}
	}

	class CloseConsole : Exception { }
}
