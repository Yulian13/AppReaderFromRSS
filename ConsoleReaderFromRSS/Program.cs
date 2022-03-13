using ConsoleReaderFromRSS.BD.Context;
using ConsoleReaderFromRSS.Controller;

namespace ConsoleReaderFromRSS
{
	class Program
	{
		static void Main(string[] args)
		{
			var newsBDContext = new NewsBDContext();
			new MonitoredConsole(newsBDContext).MonitorConsole();
		}
	}
}