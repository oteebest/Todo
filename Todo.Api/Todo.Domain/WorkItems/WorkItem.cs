using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.BaseEntities;
using Todo.Domain.Shared.WorkItems;
using Todo.Domain.Users;

namespace Todo.Domain.WorkItems
{
    public class WorkItem : IEntity
    {
        public WorkItemStatus Status { get; set; }
        public Guid TodoUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoUser TodoUser { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    }
}
