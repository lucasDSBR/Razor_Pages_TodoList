using Microsoft.EntityFrameworkCore;
using TodoListRazor.Data.EntityConfigs;
using TodoListRazor.Models;

namespace TodoListRazor.Data;

public class AppDbContext : DbContext
{
	public DbSet<Todo> Todos => Set<Todo>();

	protected override void OnConfiguring(DbContextOptionsBuilder builder)
	{
		builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoListRazor;Trusted_Connection=True;");
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfiguration(new TodoEntityConfigs());
	}
}