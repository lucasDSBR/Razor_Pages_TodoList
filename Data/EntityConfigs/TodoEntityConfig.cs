using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListRazor.Models;

namespace TodoListRazor.Data.EntityConfigs;

public class TodoEntityConfigs : IEntityTypeConfiguration<Todo>
{
	public void Configure(EntityTypeBuilder<Todo> builder)
	{
		builder.ToTable("Todos");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasColumnName("id");


		builder.Property(x => x.Title)
		.HasColumnName("title")
		.HasColumnType("nvarchar(100)")
		.IsRequired();

		builder.Property(x => x.Date)
		.HasColumnName("date")
		.HasColumnName("date")
		.IsRequired();


		builder.Property(x => x.IsCompleted)
		.HasColumnName("is_completed")
		.HasColumnType("bit")
		.IsRequired();


	}
}