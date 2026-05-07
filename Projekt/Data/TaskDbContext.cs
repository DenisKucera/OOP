using Microsoft.EntityFrameworkCore;
using Projekt.Domain;

namespace Projekt.Data;
public class TaskDbContext : DbContext
{
    public DbSet<TeamTask> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
}