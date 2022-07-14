using Todo.Application.Contracts.Model;

namespace Todo.Application.Contracts.WorkItems
{
    public interface IWorkItemService
    {
        Task<WorkItemDto> AddAsync(AddWorkItemInput input);
        Task<WorkItemDto> UpdateAsync(Guid id, UpdateWorkItemInput input);
        Task<PagedModel<WorkItemDto>> GetAsync(GetWorkItemInput input);
        Task<WorkItemDto> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task CompleteAsync(Guid id);
    }
}
