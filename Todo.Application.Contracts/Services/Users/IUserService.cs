using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Users;

namespace Todo.Application.Contracts.Services.Users
{
    public interface IUserService
    {
        Task<TodoUserDto> GetAsync(Guid id);

        Task<List<TodoUserDto>> GetAsync();
    }
}
