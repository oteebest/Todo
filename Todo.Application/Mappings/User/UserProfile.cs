using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Users;
using Todo.Domain.Users;

namespace Todo.Application.Mappings.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<TodoUser, TodoUserDto>();
        }
    }
}
