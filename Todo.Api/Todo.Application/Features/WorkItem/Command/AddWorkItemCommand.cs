using FluentValidation;
using MediatR;
using Todo.Application.Contracts.Constants;
using Todo.Application.Contracts.Services.Users;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Contracts.Wrapper;

namespace Todo.Application.Features.WorkItem.Command
{
    public class AddWorkItemCommand : IRequest<Result<WorkItemDto>>
    {
        public AddWorkItemInput AddWorkItemInput = new();
    }

    public class AddWorkItemCommandValidator : AbstractValidator<AddWorkItemCommand>
    {
        public AddWorkItemCommandValidator()
        {
            RuleFor(x => x.AddWorkItemInput.Title)
                .NotEmpty()
                .WithMessage(WorkItemValidationConstants.TitleRequired);

            RuleFor(x => x.AddWorkItemInput.Description)
                .NotEmpty()
                .WithMessage(WorkItemValidationConstants.DescriptionRequired);
        }
    }

    public class AddTaskCommandCommandHandler : IRequestHandler<AddWorkItemCommand, Result<WorkItemDto>>
    {
        private readonly IWorkItemService _workItemService;
        private readonly IUserService _userService;
        public AddTaskCommandCommandHandler(IWorkItemService workItemService, IUserService userService)
        {
            _workItemService = workItemService;
            _userService = userService;
        }

        public async Task<Result<WorkItemDto>> Handle(AddWorkItemCommand request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemService.AddAsync(request.AddWorkItemInput);
            var user = await _userService.GetAsync(workItem.TodoUserId);
            workItem.TodoUser = user;

            return Result<WorkItemDto>.Success(workItem);
        }
    }
}
