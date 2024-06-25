using Microsoft.EntityFrameworkCore;
using TransManager.Domain.Models;

namespace TransManager.Common.Persistance
{
	public class SqlLiteDb : DbContext
	{
		public DbSet<Translation> Translations { get; set; }

        public SqlLiteDb()
        {
        }

        public SqlLiteDb(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlite("Data Source=trans.db");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Translation>(entity =>
			{
				entity.HasKey(x => x.Id);
			});
		}
	}
}
