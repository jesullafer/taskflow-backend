using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.UseCases.CreateTaskItem;
using TaskFlow.Application.UseCases.DeleteTaskItem;
using TaskFlow.Application.UseCases.GetAllTaskItems;
using TaskFlow.Application.UseCases.GetTaskItemById;
using TaskFlow.Application.UseCases.UpdateTaskItem;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase{

    private readonly CreateTaskItemUseCase _createTaskItemUseCase;
    private readonly GetAllTaskItemsUseCase _getAllTaskItemsUseCase;
    private readonly GetTaskItemByIdUseCase _getTaskItemByIdUseCase;
    private readonly UpdateTaskItemUseCase _updateTaskItemUseCase;
    private readonly DeleteTaskItemUseCase _deleteTaskItemUseCase;

    public TaskItemsController(
        CreateTaskItemUseCase createTaskItemUseCase,
        GetAllTaskItemsUseCase getAllTaskItemsUseCase,
        GetTaskItemByIdUseCase getTaskItemByIdUseCase,
        UpdateTaskItemUseCase updateTaskItemUseCase,
        DeleteTaskItemUseCase deleteTaskItemUseCase)
    {
        _createTaskItemUseCase = createTaskItemUseCase;
        _getAllTaskItemsUseCase = getAllTaskItemsUseCase;
        _getTaskItemByIdUseCase = getTaskItemByIdUseCase;
        _updateTaskItemUseCase = updateTaskItemUseCase;
        _deleteTaskItemUseCase = deleteTaskItemUseCase;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskItemRequestDto request)
    {
        var response = await _createTaskItemUseCase.ExecuteAsync(request);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAllTaskItemsUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getTaskItemByIdUseCase.ExecuteAsync(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateTaskItemRequestDto request)
    {
        var result = await _updateTaskItemUseCase.ExecuteAsync(id, request);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _deleteTaskItemUseCase.ExecuteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}