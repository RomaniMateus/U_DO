using Microsoft.EntityFrameworkCore;
using U_DO.Models;

namespace U_DO.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
