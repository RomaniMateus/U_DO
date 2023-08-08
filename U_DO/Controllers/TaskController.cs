using Microsoft.AspNetCore.Mvc;
using U_DO.Models;

namespace U_DO.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private static List<ToDoTask> tasks = new List<ToDoTask>();
    private static int id = 0;
    [HttpPost]
    public IActionResult AddTask([FromBody] ToDoTask task)
    {
        // Add task
        task.Id = id++;
        tasks.Add(task);

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpGet]
    public IEnumerable<ToDoTask> GetTasks()
    {
        // Get tasks
        return tasks;
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        // Get task by id
        var task = tasks.FirstOrDefault(task => task.Id == id);

        if (task == null) return NotFound();

        return Ok(task);
    }
}
