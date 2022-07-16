using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.WorkItems;

namespace Todo.EntityFramework.EntityConfiguration.WorkItems
{
    public class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Title).IsRequired();
            builder.HasOne(u => u.TodoUser).WithMany(u => u.WorkItem);            
        }
    }
}
