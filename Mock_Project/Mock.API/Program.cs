using Microsoft.EntityFrameworkCore;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.UserService;
using Mock.Core.Data;
using Mock.Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IBorrowingService, Borrowing>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddDbContext<LivebraryContext>(option =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseSqlServer(conn);
});

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", policy => 
    { 
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();


app.MapControllers();

app.Run();
