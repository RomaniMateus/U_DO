using System.ComponentModel.DataAnnotations;

namespace U_DO.Data.DTO
{
    public class UpdateTaskDto
    {
        [Required(ErrorMessage = "The title of the task is mandatory!")]
        [StringLength(3, ErrorMessage = "The title must be at least 3 characters long!")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The status of the task is mandatory!")]
        public Boolean IsComplete { get; set; }

        [Required(ErrorMessage = "The due date of the task is mandatory!")]
        public DateTime DueDate { get; set; }
    }
}