using Microsoft.EntityFrameworkCore;
using WebApiApp.Entities.Employee;

namespace WebApiApp.Context
{
	public class TestDbContext : DbContext
	{
		public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
		{
		}

		//entities
		public DbSet<TblEmpData> TblEmpData { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//entities
			modelBuilder.Entity<TblEmpData>(entity => { entity.HasKey(id => new { id.Id }); });
		}
	}
}
