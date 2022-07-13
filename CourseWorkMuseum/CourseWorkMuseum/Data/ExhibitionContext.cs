using CourseWorkMuseum.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace CourseWorkMuseum.Data;

public class ExhibitionContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        base.OnConfiguring(optionsBuilder); 

        optionsBuilder.UseNpgsql(@"Host=localhost;Database=museum_course_work;Username=postgres;Password=khilalovartem")
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(builder => 
                builder.AddConsole())).EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Exhibition>().Property(p => p.ExhibitionId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Exhibit>().Property(p => p.ExhibitId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Ticket>().Property(p => p.TicketId).ValueGeneratedOnAdd();
       
    }

    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Exhibit> Exhibits { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}