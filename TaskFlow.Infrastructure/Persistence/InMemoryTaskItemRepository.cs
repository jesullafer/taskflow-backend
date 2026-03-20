using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence;

public class InMemoryTaskItemRepository : ITaskItemRepository
{
    private readonly List<TaskItem> _tasks = new();

    public Task<List<TaskItem>> GetAllAsync()
    {
        return Task.FromResult(_tasks);
    }

    public Task<TaskItem?> GetByIdAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(task);
    }

    public Task AddAsync(TaskItem taskItem)
    {
        _tasks.Add(taskItem);
        return Task.CompletedTask;
    }
}