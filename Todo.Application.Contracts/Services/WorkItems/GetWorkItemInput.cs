using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Shared.WorkItems;

namespace Todo.Application.Contracts.WorkItems
{
    public class GetWorkItemInput
    {
        public Guid? OwnerTodoUserId { get; set; }
        public WorkItemStatus? WorkItemStatus { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
