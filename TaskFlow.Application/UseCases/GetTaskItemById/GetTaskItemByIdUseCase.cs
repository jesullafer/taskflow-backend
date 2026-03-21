using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Application.UseCases.GetTaskItemById;

public class GetTaskItemByIdUseCase
{
    private readonly ITaskItemRepository _repository;

    public GetTaskItemByIdUseCase(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskItemResponseDto?> ExecuteAsync(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task is null)
            return null;

        return new TaskItemResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        };
    }
}