using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Controllers.Base;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Features.User.Query;
using Todo.Application.Features.WorkItem.Command;
using Todo.Application.Features.WorkItem.Query;

namespace Todo.Api.Controllers
{
    public class UsersController : BaseController<WorkItemsController>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetUsersQuery { }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserQuery { Id = id }));
        }
    }
}
