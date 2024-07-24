using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TodoList.Entitys;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<TodoEntity> TodoList { get; set; }
    
}