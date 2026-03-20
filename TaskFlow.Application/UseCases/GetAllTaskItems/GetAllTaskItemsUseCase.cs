using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.UseCases.GetAllTaskItems;

public class GetAllTaskItemsUseCase
{
    private readonly ITaskItemRepository _repository;

    public GetAllTaskItemsUseCase(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TaskItemResponseDto>> ExecuteAsync()
    {
        var tasks = await _repository.GetAllAsync();

        return tasks.Select(task => new TaskItemResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        }).ToList();
    }
}