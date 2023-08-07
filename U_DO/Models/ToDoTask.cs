using System.ComponentModel.DataAnnotations;

namespace U_DO.Models;

public class ToDoTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The title of the task is mandatory!")]
    [MinLength(3, ErrorMessage = "The title must be at least 3 characters long!")]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "The status of the task is mandatory!")]
    public Boolean IsComplete { get; set; }

    [Required(ErrorMessage = "The due date of the task is mandatory!")]
    public DateTime DueDate { get; set; }
}
public static class DateHelper
{
    public static string FormatDueDate(DateTime dueDate)
    {
        return dueDate.ToString("MMMM dd, yyyy - hh:mm tt");
    }
}
