using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.UseCases.CreateTaskItem;
using TaskFlow.Application.UseCases.GetAllTaskItems;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase{

    private readonly CreateTaskItemUseCase _createTaskItemUseCase;
    private readonly GetAllTaskItemsUseCase _getAllTaskItemsUseCase;

    public TaskItemsController(
        CreateTaskItemUseCase createTaskItemUseCase,
        GetAllTaskItemsUseCase getAllTaskItemsUseCase)
    {
        _createTaskItemUseCase = createTaskItemUseCase;
        _getAllTaskItemsUseCase = getAllTaskItemsUseCase;
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
}