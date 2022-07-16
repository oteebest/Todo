using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Constants;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Contracts.Wrapper;

namespace Todo.Application.Features.WorkItem.Command
{
    public class CompletWorkItemCommand : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
    }

    public class CompletWorkItemCommandHandler : IRequestHandler<CompletWorkItemCommand, Result<string>>
    {
        private readonly IWorkItemService _taskService;

        public CompletWorkItemCommandHandler(IWorkItemService taskService)
        {
            _taskService = taskService;
        }

        public async Task<Result<string>> Handle(CompletWorkItemCommand request, CancellationToken cancellationToken)
        {
            await _taskService.CompleteAsync(request.Id);

            return Result<string>.Success(MessageConstants.WorkItemCompleted);
        }
    }
}
