using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Infrastructure.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo.Domain.Entity.Todo>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Todo> builder)
        {
            builder.ToTable(nameof(Todo.Domain.Entity.Todo));
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Body).IsRequired().HasMaxLength(200);
            builder.Property(t => t.ExecutionDate).IsRequired().HasMaxLength(200);

        }
    }
}
