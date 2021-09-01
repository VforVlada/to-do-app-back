using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
