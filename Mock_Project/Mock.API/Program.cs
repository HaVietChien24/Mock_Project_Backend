using Microsoft.EntityFrameworkCore;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.BorrowingService;
using Mock.Core.Data;
using Mock.Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBorrowingService,BorrowingService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddDbContext<LivebraryContext>(option =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseSqlServer(conn);
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("AllowAnyOrigin");
app.MapControllers();

app.Run();
