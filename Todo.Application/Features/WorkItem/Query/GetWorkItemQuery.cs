using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Model;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Contracts.Wrapper;

namespace Todo.Application.Features.WorkItem.Query
{
    public class GetWorkItemQuery : IRequest<Result<WorkItemDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetWorkItemQueryHandler : IRequestHandler<GetWorkItemQuery, Result<WorkItemDto>>
    {
        private readonly IWorkItemService _taskService;

        public GetWorkItemQueryHandler(IWorkItemService taskService)
        {
            _taskService = taskService;
        }

        public async Task<Result<WorkItemDto>> Handle(GetWorkItemQuery request, CancellationToken cancellationToken)
        {
            var workItem = await _taskService.GetAsync(request.Id);

            return Result<WorkItemDto>.Success(workItem);
        }
    }
}
