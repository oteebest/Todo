using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Users;

namespace Todo.EntityFramework.EntityConfiguration.Users
{
    internal class TodoUserConfiguration : IEntityTypeConfiguration<TodoUser>
    {
        public void Configure(EntityTypeBuilder<TodoUser> builder)
        {
            builder.Property(u => u.Name).IsRequired();
        }
    }
}
