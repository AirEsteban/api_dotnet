using Microsoft.EntityFrameworkCore;
using webapi.Models;
using Microsoft.Extensions.Configuration;
using Api_dotnet.Controllers;
using Microsoft.Win32.SafeHandles;

namespace webapi;

public class MyDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Category> Categories {get;set;}
    public DbSet<Tasks> Tasks {get;set;}

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Actividades pendientes", Weight = 20});
        categoryInit.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Actividades personales", Weight = 50});


        modelBuilder.Entity<Category>(categoria=> 
        {
            categoria.ToTable("Categories");
            categoria.HasKey(p=> p.CategoryId);

            categoria.Property(p=> p.Name).IsRequired().HasMaxLength(150);

            categoria.Property(p=> p.Description).IsRequired(false);

            categoria.Property(p=> p.Weight);

            categoria.HasData(categoryInit);
        });

        List<Tasks> tasksInit = new List<Tasks>();

        tasksInit.Add(new Tasks() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Priority = Priority.Medium, Title = "Pago de servicios publicos", CreationDate = DateTime.Now });
        tasksInit.Add(new Tasks() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Priority = Priority.Low, Title = "Terminar de ver pelicula en netflix", CreationDate = DateTime.Now });

        modelBuilder.Entity<Tasks>(tarea=>
        {
            tarea.ToTable("Tasks");
            tarea.HasKey(p=> p.TaskId);

            tarea.HasOne(p=> p.Category).WithMany(p=> p.Tasks).HasForeignKey(p=> p.CategoryId);

            tarea.Property(p=> p.Title).IsRequired().HasMaxLength(200);

            tarea.Property(p=> p.Description).IsRequired(false);

            tarea.Property(p=> p.Priority);

            tarea.Property(p=> p.CreationDate);

            tarea.Ignore(p=> p.Resumee);

            tarea.HasData(tasksInit);

        });

    }

}