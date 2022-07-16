using Microsoft.AspNetCore.Identity;
using Todo.Domain.BaseEntities;
using Todo.Domain.WorkItems;

namespace Todo.Domain.Users
{
    public class TodoUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public IEnumerable<WorkItem> WorkItem { get; set; }
    }

    public class TodoIdentityRole : IdentityRole<Guid>
    {

    }
}
