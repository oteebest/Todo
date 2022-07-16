using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Db;
using Todo.Domain.Users;

namespace Todo.Application.Db
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IDatabaseService _dbService;
        private readonly UserManager<TodoUser> _userManager;
        public DatabaseSeeder(IDatabaseService dbService, UserManager<TodoUser> userManager)
        {
            _dbService = dbService;
            _userManager = userManager;
        }
        public void Initialise(bool shouldSeed)
        {
            if(shouldSeed)
            {
                if (!_dbService.TodoUsers.Any(u => u.UserName == "admin"))
                {
                    var adminUser = new TodoUser { UserName = "admin", Email = "admin@todo.com", Name = "Admin User" };
                    _userManager.CreateAsync(adminUser, "admin");
                }

                //add other user
                if (!_dbService.TodoUsers.Any(u => u.UserName == "otee"))
                {
                    var adminUser = new TodoUser { UserName = "otee", Email = "otee@todo.com", Name = "Otee Best" };
                    _userManager.CreateAsync(adminUser, "admin");
                }

                if (!_dbService.TodoUsers.Any(u => u.UserName == "john"))
                {
                    var adminUser = new TodoUser { UserName = "john", Email = "john@todo.com", Name = "John Smith" };
                    _userManager.CreateAsync(adminUser, "admin");
                }

                if (!_dbService.TodoUsers.Any(u => u.UserName == "james"))
                {
                    var adminUser = new TodoUser { UserName = "james", Email = "james@todo.com", Name = "James Jones" };
                    _userManager.CreateAsync(adminUser, "admin");
                }

                if (!_dbService.TodoUsers.Any(u => u.UserName == "jude"))
                {
                    var adminUser = new TodoUser { UserName = "jude", Email = "jude@todo.com", Name = "Jude Zain" };
                    _userManager.CreateAsync(adminUser, "admin");
                }
            }           
        }
    }
}
