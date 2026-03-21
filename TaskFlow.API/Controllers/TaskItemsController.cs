using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.UseCases.CreateTaskItem;
using TaskFlow.Application.UseCases.GetAllTaskItems;
using TaskFlow.Application.UseCases.GetTaskItemById;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase{

    private readonly CreateTaskItemUseCase _createTaskItemUseCase;
    private readonly GetAllTaskItemsUseCase _getAllTaskItemsUseCase;
    private readonly GetTaskItemByIdUseCase _getTaskItemByIdUseCase;

    public TaskItemsController(
        CreateTaskItemUseCase createTaskItemUseCase,
        GetAllTaskItemsUseCase getAllTaskItemsUseCase,
        GetTaskItemByIdUseCase getTaskItemByIdUseCase)
    {
        _createTaskItemUseCase = createTaskItemUseCase;
        _getAllTaskItemsUseCase = getAllTaskItemsUseCase;
        _getTaskItemByIdUseCase = getTaskItemByIdUseCase;
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
}