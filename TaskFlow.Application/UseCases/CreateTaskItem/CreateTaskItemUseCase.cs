using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.UseCases.CreateTaskItem;

public class CreateTaskItemUseCase
{
    private readonly ITaskItemRepository _repository;

    public CreateTaskItemUseCase(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskItemResponseDto> ExecuteAsync(CreateTaskItemRequestDto request)
    {
        var task = new TaskItem(request.Title, request.Description);

        await _repository.AddAsync(task);

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