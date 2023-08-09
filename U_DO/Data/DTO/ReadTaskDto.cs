using System.ComponentModel.DataAnnotations;

namespace U_DO.Data.DTO;

public class ReadTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Boolean IsComplete { get; set; }
    public DateTime DueDate { get; set; }
}
