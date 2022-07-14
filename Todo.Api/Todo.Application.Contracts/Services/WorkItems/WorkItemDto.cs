using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Users;

namespace Todo.Application.Contracts.WorkItems
{
    public class WorkItemDto
    {
        public TaskStatus Status { get; set; }
        public Guid TodoUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoUserDto TodoUser { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
