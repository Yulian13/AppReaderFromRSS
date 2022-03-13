namespace ConsoleReaderFromRSS.Parser
{
	class XmlParserFromIxbt : XmlNewsParser
	{
		private const string _LinkXMLNews = @"http://www.ixbt.com/export/news.rss";
		private const string _Sourse = @"ixbt.com";

		public XmlParserFromIxbt() : base(_LinkXMLNews, _Sourse) { }
	}
}
