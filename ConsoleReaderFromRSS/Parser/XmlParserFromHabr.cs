namespace ConsoleReaderFromRSS.Parser
{
	class XmlParserFromHabr : XmlNewsParser
	{
		private const string _LinkXMLNews = @"https://habr.com/ru/rss/all/all/";
		private const string _Sourse = @"habr.com";

		public XmlParserFromHabr() : base(_LinkXMLNews, _Sourse) { }
	}
}
