using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Contracts.Db;
using Todo.Domain.Users;
using Todo.Domain.WorkItems;
using Todo.EntityFramework.EntityConfiguration.WorkItems;
using Todo.EntityFramework.EntityConfiguration.Users;

namespace Todo.EntityFramework.Context
{
    public class ApplicationDbContext : IdentityDbContext<TodoUser, TodoIdentityRole, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>, IDatabaseService
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TodoUser> TodoUsers { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }

        public Task<int> SaveAsync()
        {
            return SaveChangesAsync(new CancellationToken());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WorkItemConfiguration());
            builder.ApplyConfiguration(new TodoUserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
