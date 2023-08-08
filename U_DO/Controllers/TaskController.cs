using Microsoft.AspNetCore.Mvc;
using U_DO.Data;
using U_DO.Models;

namespace U_DO.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private TaskContext _context;

    public TaskController(TaskContext context)
    {
        _context = context;
    }


    [HttpPost]
    public IActionResult AddTask([FromBody] ToDoTask task)
    {
        // Add task
        _context.Tasks.Add(task);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpGet]
    public IEnumerable<ToDoTask> GetTasks()
    {
        // Get tasks
        return _context.Tasks;
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        // Get task by id
        var task = _context.Tasks.FirstOrDefault(task => task.Id == id);

        if (task == null) return NotFound();

        return Ok(task);
    }
}
