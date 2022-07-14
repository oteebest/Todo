using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Contracts.Constants;
using Todo.Application.Contracts.Db;
using Todo.Application.Contracts.Model;
using Todo.Application.Contracts.WorkItems;
using Todo.Application.Extensions;
using Todo.Domain.Shared.WorkItems;

namespace Todo.Application.Services.WorkItem
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IDatabaseService _dbService;
        private readonly IMapper _mapper;
        public WorkItemService(IDatabaseService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public async Task<WorkItemDto> AddAsync(AddWorkItemInput input)
        {
            var workItem = _mapper.Map<Domain.WorkItems.WorkItem>(input);
            workItem.Status = WorkItemStatus.InProgress;
            _dbService.WorkItems.Add(workItem);
            await _dbService.SaveAsync();

            return _mapper.Map<WorkItemDto>(workItem);
        }

        public async Task DeleteAsync(Guid id)
        {
            var workItem = await _dbService.WorkItems.FirstOrDefaultAsync(u => u.Id == id);
            _dbService.WorkItems.Remove(workItem);
            await _dbService.SaveAsync();
        }

        public async Task CompleteAsync(Guid id)
        {
            var workItem = await _dbService.WorkItems.FirstOrDefaultAsync(u => u.Id == id);

            if(workItem == null)
            {
                throw new KeyNotFoundException(MessageConstants.NotFoundException);
            }
            workItem.Status = WorkItemStatus.Completed;
            await _dbService.SaveAsync();
        }

        public async Task<WorkItemDto> GetAsync(Guid id)
        {
            var workItem = await _dbService.WorkItems.FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<WorkItemDto>(workItem);
        }

        public async Task<PagedModel<WorkItemDto>> GetAsync(GetWorkItemInput input)
        {
            var queryable = _dbService.WorkItems.AsQueryable();

            if(input.OwnerTodoUserId.HasValue)
            {
                queryable = queryable.Where(u => u.TodoUserId == input.OwnerTodoUserId);
            }

            if(input.WorkItemStatus.HasValue)
            {
                queryable = queryable.Where(u => u.Status == input.WorkItemStatus);
            }

            var workItems = await queryable.Include( u => u.TodoUser).OrderBy(u => u.CreatedOn).ToPagedListAsync(input.PageNumber, input.PageSize);

            return new PagedModel<WorkItemDto>(workItems.Items.Select(u => _mapper.Map<WorkItemDto>(u)).ToArray(),
                         workItems.TotalSize, workItems.PageNumber, workItems.PageSize);
        }

        public async Task<WorkItemDto> UpdateAsync(Guid id, UpdateWorkItemInput input)
        {
            var task = await _dbService.WorkItems.FirstAsync(u => u.Id == id);

            task.Title = input.Title;
            task.Description = input.Description;
            task.TodoUserId = input.TodoUserId;
            await _dbService.SaveAsync();

            return _mapper.Map<WorkItemDto>(task);
        }
    }
}
