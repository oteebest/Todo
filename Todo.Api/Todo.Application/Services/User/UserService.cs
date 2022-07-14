using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Services.Users;
using Todo.Application.Contracts.Users;
using Todo.Domain.Users;

namespace Todo.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<TodoUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<TodoUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<TodoUserDto> GetAsync(Guid id)
        {
            var user =  await _userManager.FindByIdAsync(id.ToString());
            
            return _mapper.Map<TodoUserDto>(user);
        }

        public async Task<List<TodoUserDto>> GetAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<TodoUserDto>>(users);
        }
    }
}
