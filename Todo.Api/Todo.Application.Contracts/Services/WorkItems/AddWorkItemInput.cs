using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Contracts.WorkItems
{
    public class AddWorkItemInput
    {
        public Guid TodoUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
