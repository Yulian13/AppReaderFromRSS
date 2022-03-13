﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebReaderFromRSS.BD.Models
{
	public class News
	{
		[Key]
		public string UrlLink { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PublicationDate { get; set; }
		public string NewsSourсeId { get; set; }
	}
}
