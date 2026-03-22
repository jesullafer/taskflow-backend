using TaskFlow.Application.Interfaces;
using TaskFlow.Application.UseCases.CreateTaskItem;
using TaskFlow.Application.UseCases.GetAllTaskItems;
using TaskFlow.Application.UseCases.GetTaskItemById;
using TaskFlow.Application.UseCases.UpdateTaskItem;
using TaskFlow.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITaskItemRepository, InMemoryTaskItemRepository>();
builder.Services.AddScoped<CreateTaskItemUseCase>();
builder.Services.AddScoped<GetAllTaskItemsUseCase>();
builder.Services.AddScoped<GetTaskItemByIdUseCase>();
builder.Services.AddScoped<UpdateTaskItemUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
