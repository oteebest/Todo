using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Contracts.Users
{
    public class TodoUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
