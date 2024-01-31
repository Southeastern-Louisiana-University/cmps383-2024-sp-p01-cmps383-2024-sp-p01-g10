using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Features.Hotel;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Hotel> Hotel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
   
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel { Id = 1, Name = "Hotel 1", Address = "This is the first address" },
            new Hotel { Id = 2, Name = "Hotel 2", Address = "This is the second address" },
            new Hotel { Id = 3, Name = "Hotel 3", Address = "This is the third address" }

            ); ;
    }

}