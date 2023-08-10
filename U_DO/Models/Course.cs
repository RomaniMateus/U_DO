using System.ComponentModel.DataAnnotations;

namespace U_DO.Models;

public class Course
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "The name of the course is mandatory!")]
    [MinLength(10, ErrorMessage = "The name must be at least 10 characters long!")]
    public string Name { get; set; }

}
