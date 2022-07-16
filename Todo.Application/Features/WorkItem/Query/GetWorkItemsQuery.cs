using MediatR;
using Todo.Application.Contracts.Model;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Contracts.Wrapper;

namespace Todo.Application.Features.WorkItem.Query
{
    public class GetWorkItemsQuery : IRequest<Result<PagedModel<WorkItemDto>>>
    {
        public GetWorkItemInput GetWorkItemInput = new();
    }

    public class GetWorkItemsQueryHandler : IRequestHandler<GetWorkItemsQuery, Result<PagedModel<WorkItemDto>>>
    {
        private readonly IWorkItemService _taskService;

        public GetWorkItemsQueryHandler(IWorkItemService taskService)
        {
            _taskService = taskService;
        }

        public async Task<Result<PagedModel<WorkItemDto>>> Handle(GetWorkItemsQuery request, CancellationToken cancellationToken)
        {
            var workItems = await _taskService.GetAsync(request.GetWorkItemInput);

            return Result<PagedModel<WorkItemDto>>.Success(workItems);
        }
    }
}
