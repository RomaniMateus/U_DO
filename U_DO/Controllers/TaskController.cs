using Microsoft.AspNetCore.Mvc;
using U_DO.Models;

namespace U_DO.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private static List<ToDoTask> tasks = new List<ToDoTask>();

    [HttpPost]
    public void AddTask([FromBody] ToDoTask task)
    {
        // Add task
        tasks.Add(task);
        Console.WriteLine($"Added task: {task.Title}");
        Console.WriteLine($"Description: {task.Description}");
        Console.WriteLine($"IsComplete: {task.IsComplete}");
        Console.WriteLine($"DueDate: {DateHelper.FormatDueDate(task.DueDate)}");
    }

    [HttpGet]
    public List<ToDoTask> GetTasks()
    {
        // Get tasks
        return tasks;
    }
}
