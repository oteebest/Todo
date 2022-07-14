using MediatR;
using Todo.Application.Contracts.Services.Users;
using Todo.Application.Contracts.Users;
using Todo.Application.Contracts.Wrapper;
using Todo.Domain.Users;

namespace Todo.Application.Features.User.Query
{
    public class GetUsersQuery : IRequest<Result<List<TodoUserDto>>>
    {

    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<TodoUserDto>>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<List<TodoUserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAsync();

            return Result<List<TodoUserDto>>.Success(users);
        }
    }
}
