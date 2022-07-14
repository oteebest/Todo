using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Constants;
using Todo.Application.Contracts.Services.Users;
using Todo.Application.Contracts.Users;
using Todo.Application.Contracts.Wrapper;

namespace Todo.Application.Features.User.Query
{
    public class GetUserQuery : IRequest<Result<TodoUserDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUserQueryQueryHandler : IRequestHandler<GetUserQuery, Result<TodoUserDto>>
    {
        private readonly IUserService _userService;

        public GetUserQueryQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<TodoUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetAsync(request.Id);

            if(user == null)
            {
                throw new KeyNotFoundException(MessageConstants.NotFoundException);
            }

            return Result<TodoUserDto>.Success(user);
        }
    }
}
