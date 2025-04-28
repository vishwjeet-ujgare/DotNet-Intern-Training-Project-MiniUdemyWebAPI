using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.Models.UserModels;

using MiniUdemyWebAPI.Repositories.Implementations.Admin.User;
using MiniUdemyWebAPI.Repositories.Implementations.Course;

using MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users;
using MiniUdemyWebAPI.Repositories.Interfaces.Course;

using MiniUdemyWebAPI.Services.Admin.Users;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICourseRepository, CourseRepository>();

//Registering DbContext
builder.Services.AddDbContext<MiniUdemyDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiniUdemyDB")));


//registering identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MiniUdemyDBContext>()
    .AddDefaultTokenProviders();

//For authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
}
);

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
         {
              new OpenApiSecurityScheme
         {
                 Reference = new OpenApiReference
                    {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                    }
          },
        new string[] {}
     }
    });
});



// Register your repositories
builder.Services.AddScoped<IUserAdminRepository, UserAdminRepository>();
builder.Services.AddScoped<IUserProfileAdminRepository, UserProfileAdminRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// Register your services
builder.Services.AddScoped<IUserAdminService, UserAdminService>();



builder.Services.AddControllers();



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
