using ConsoleReaderFromRSS.BD.Models;
using ConsoleReaderFromRSS.Parser;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace ConsoleReaderFromRSS.Controller
{
	class NewsManager
	{
		private List<XmlNewsParser> _XmlNewsParsers = new List<XmlNewsParser>() {
			new XmlParserFromHabr(),
			new XmlParserFromIxbt()
		};

		public IEnumerable<string> GetSourceCollection()
			=> _XmlNewsParsers.Select(x => x.GetSourses());

		public List<News> GetNewsCollection()
		{
			var news = new List<News>();

			foreach (XmlNewsParser parser in _XmlNewsParsers)
			{
				string urlSourse = parser.GetLinkXMLNews();
				XmlDocument xmlDocument = GetXmlDocument(urlSourse);
				List<News> newsFromParser = parser.GetNews(xmlDocument);
				news.AddRange(newsFromParser);
			}

			return news;
		}

		private XmlDocument GetXmlDocument(string urlSourse)
		{
			var xmlDocument = new XmlDocument();

			WebResponse resp = WebRequest.Create(urlSourse).GetResponse();
			Stream stream = resp.GetResponseStream();
			var sr = new StreamReader(stream);
			string response = sr.ReadToEnd();
			xmlDocument.LoadXml(response);

			return xmlDocument;
		}
	}
}
