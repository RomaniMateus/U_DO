using System.ComponentModel.DataAnnotations;

namespace U_DO.Data.DTO;

public class CreateCourseDto
{
    [Required(ErrorMessage = "The name of the course is mandatory!")]
    [StringLength(50, ErrorMessage = "The name must be at least 3 characters long!")]
    public string Name { get; set; }

}
