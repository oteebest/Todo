using AutoMapper;
using Todo.Application.Contracts.WorkItems;
using Todo.Domain.WorkItems;

namespace Todo.Application.Mappings.Task
{
    public class WorkItemProfile : Profile
    {
        public WorkItemProfile()
        {
            CreateMap<AddWorkItemInput, Todo.Domain.WorkItems.WorkItem>();

            CreateMap<UpdateWorkItemInput, Todo.Domain.WorkItems.WorkItem>();

            CreateMap<Todo.Domain.WorkItems.WorkItem, WorkItemDto>();
        }
    }
}
