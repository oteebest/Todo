using FluentValidation;
using MediatR;
using Todo.Application.Contracts.Constants;
using Todo.Application.Contracts.Services.Users;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Contracts.Wrapper;

namespace Todo.Application.Features.WorkItem.Command
{
    public class UpdateWorkItemCommand : IRequest<Result<WorkItemDto>>
    {
        public Guid Id { get; set; }
        public UpdateWorkItemInput UpdateWorkItemInput = new();
    }

    public class UpdateWorkItemCommandValidator : AbstractValidator<UpdateWorkItemCommand>
    {
        public UpdateWorkItemCommandValidator()
        {
            RuleFor(x => x.UpdateWorkItemInput.Title)
                .NotEmpty()
                .WithMessage(WorkItemValidationConstants.TitleRequired);

            RuleFor(x => x.UpdateWorkItemInput.Description)
                .NotEmpty()
                .WithMessage(WorkItemValidationConstants.DescriptionRequired);
        }
    }

    public class UpdateWorkItemCommandHandler : IRequestHandler<UpdateWorkItemCommand, Result<WorkItemDto>>
    {
        private readonly IWorkItemService _workItemService;
        private readonly IUserService _userService;
        public UpdateWorkItemCommandHandler(IWorkItemService workItemService, IUserService userService)
        {
            _workItemService = workItemService;
            _userService = userService;
        }

        public async Task<Result<WorkItemDto>> Handle(UpdateWorkItemCommand request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemService.UpdateAsync(request.Id, request.UpdateWorkItemInput);
            var user = await _userService.GetAsync(workItem.TodoUserId);
            workItem.TodoUser = user;

            return Result<WorkItemDto>.Success(workItem);
        }
    }
}
