using CQRSNight.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSNight.Context;

public class CQRSContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=NETCADYAZ;initial catalog=CQRSNightDb;integrated security=true");
	}


	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }
}
