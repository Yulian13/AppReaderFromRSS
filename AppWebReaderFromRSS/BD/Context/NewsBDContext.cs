using AppWebReaderFromRSS.BD.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebReaderFromRSS.BD.Context
{
	public class NewsBDContext : DbContext
	{
		public DbSet<News> News { get; set; }
		public DbSet<NewsSourсe> NewsSourсes { get; set; }

		public NewsBDContext(DbContextOptions<NewsBDContext> options) : base(options) { }
	}
}
