using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.Repositories.Implementations.CourseRepository;
using MiniUdemyWebAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddDbContext<MiniUdemyDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiniUdemyDB")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//for serving file from wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
