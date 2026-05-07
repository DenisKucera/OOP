using Microsoft.AspNetCore.Mvc;
using Projekt.Services;
using Projekt.Web.DTOs;

namespace Projekt.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] CreateTaskDTO request)
    {
        _taskService.CreateNewTask(request.Title, request.Description);
        return Ok("Úkol byl úspěšně vytvořen.");
    }

    [HttpGet]
    public IActionResult GetTasks([FromQuery] int? assigneeId, [FromQuery] bool? isCompleted)
    {
        var tasks = _taskService.GetTasksFiltered(assigneeId, isCompleted);
        return Ok(tasks);
    }

    [HttpPut("{id}/state")]
    public IActionResult UpdateState(int id, [FromBody] TaskState newState)
    {
        try
        {
            _taskService.ChangeTaskState(id, newState);
            return Ok("Stav byl změněn.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{taskId}/assign/{userId}")]
    public IActionResult AssignTask(int taskId, int userId)
    {
        try
        {
            _taskService.AssignTaskToUser(taskId, userId);
            return Ok("Úkol byl úspěšně přiřazen uživateli.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        try
        {
            _taskService.DeleteTask(id);
            return Ok($"Úkol s ID {id} byl úspěšně smazán.");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message); 
        }
    }
}

