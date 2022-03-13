using ConsoleReaderFromRSS.BD.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleReaderFromRSS.Parser
{
	class XmlNewsParser
	{
		private readonly string _LinkXMLNews;
		private readonly string _Sourse;

		public XmlNewsParser(string linkXMLNews, string sourse)
		{
			_LinkXMLNews = linkXMLNews;
			_Sourse = sourse;
		}

		public string GetLinkXMLNews() => _LinkXMLNews;
		public string GetSourses() => _Sourse;

		public List<News> GetNews(XmlDocument xmlDocument)
		{
			var newsCollection = new List<News>();

			XmlElement xmlRoot = xmlDocument.DocumentElement;
			XmlNodeList xmlItems = xmlRoot.GetElementsByTagName("item");
			foreach (XmlNode xmlItem in xmlItems)
			{
				News news = GetNewsFromItem(xmlItem);
				newsCollection.Add(news);
			}

			return newsCollection;
		}

		protected virtual News GetNewsFromItem(XmlNode xmlItem)
		{
			var news = new News();

			news.UrlLink			= xmlItem["guid"].InnerText;
			news.Description		= xmlItem["description"].InnerText;
			news.Title				= xmlItem["title"].InnerText;
			news.PublicationDate	= Convert.ToDateTime(xmlItem["pubDate"].InnerText);
			news.NewsSourсeId				= _Sourse;

			return news;
		}
	}
}
