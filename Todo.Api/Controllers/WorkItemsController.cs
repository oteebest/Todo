using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Controllers.Base;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Features.WorkItem.Command;
using Todo.Application.Features.WorkItem.Query;

namespace Todo.Api.Controllers
{
    public class WorkItemsController : BaseController<WorkItemsController>
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddWorkItemInput input)
        {
            return Ok( await _mediator.Send(new AddWorkItemCommand { AddWorkItemInput = input }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorkItemInput input)
        {            
            return Ok(await _mediator.Send(new UpdateWorkItemCommand { Id = id, UpdateWorkItemInput = input }));
        }

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete(Guid id)
        {
            return Ok(await _mediator.Send(new CompletWorkItemCommand { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWorkItemInput input)
        {
            return Ok(await _mediator.Send(new GetWorkItemsQuery { GetWorkItemInput = input }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetWorkItemQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteWorkItemCommand { Id = id }));
        }
    }
}
