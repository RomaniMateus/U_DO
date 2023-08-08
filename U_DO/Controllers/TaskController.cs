using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using U_DO.Data;
using U_DO.Data.DTO;
using U_DO.Models;

namespace U_DO.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private TaskContext _context;
    private IMapper _mapper;
    public TaskController(TaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddTask([FromBody] CreateTaskDto taskDto)
    {

        // Add task
        ToDoTask task = _mapper.Map<ToDoTask>(taskDto);
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
