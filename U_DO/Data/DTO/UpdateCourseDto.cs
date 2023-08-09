using System.ComponentModel.DataAnnotations;

namespace U_DO.Data.DTO;

public class UpdateTaskDto
{
    [Required(ErrorMessage = "The title of the task is mandatory!")]
    [StringLength(50, ErrorMessage = "The title must be at least 3 characters long!")]
    public string Title { get; set; }

}
