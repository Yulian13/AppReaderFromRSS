using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReaderFromRSS.BD.Models
{
	public class NewsSourсe
	{
		[Key]
		public string Sourсe { get; set; }
		public List<News> NewsCollection { get; set; } = new List<News>();

		public NewsSourсe(string sourсe)
		{
			Sourсe = sourсe;
		}
	}
}
