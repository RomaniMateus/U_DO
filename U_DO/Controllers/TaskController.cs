using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] UpdateTaskDto taskDto)
    {
        // Update task
        var task = _context.Tasks.FirstOrDefault(task => task.Id == id);

        if (task == null) return NotFound();

        _mapper.Map(taskDto, task);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateTaskPatch(int id, [FromBody] JsonPatchDocument<UpdateTaskDto> patchDoc)
    {
        // Update task
        var task = _context.Tasks.FirstOrDefault(task => task.Id == id);
        if (task == null) return NotFound();

        var taskToPatch = _mapper.Map<UpdateTaskDto>(task);
        patchDoc.ApplyTo(taskToPatch, ModelState);

        if (!TryValidateModel(taskToPatch)) return ValidationProblem(ModelState);

        _mapper.Map(taskToPatch, task);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        // Delete task
        var task = _context.Tasks.FirstOrDefault(task => task.Id == id);

        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return NoContent();
    }
}
