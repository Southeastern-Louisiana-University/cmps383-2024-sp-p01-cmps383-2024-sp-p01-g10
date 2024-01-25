using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Features.Hotel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

var app = builder.Build();

var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
db.Database.Migrate();
db.Set<Hotel>().AddRange(new List<Hotel>
{
            new Hotel { Name = "Hotel 1", Address = "This is the first address" },
            new Hotel { Name = "Hotel 2", Address = "This is the second address" },
            new Hotel { Name = "Hotel 3", Address = "This is the third address" }
});
db.SaveChanges();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//see: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0
// Hi 383 - this is added so we can test our web project automatically
public partial class Program {

}