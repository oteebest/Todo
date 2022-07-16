using Microsoft.EntityFrameworkCore;
using Todo.Domain.Users;
using Todo.Domain.WorkItems;

namespace Todo.Application.Contracts.Db
{
    public interface IDatabaseService
    {
        DbSet<TodoUser> TodoUsers { get; set; }
        DbSet<WorkItem> WorkItems { get; set; }
        Task<int> SaveAsync();
    }
}
