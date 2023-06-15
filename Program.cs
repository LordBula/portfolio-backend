using Microsoft.EntityFrameworkCore;
using DotNetApi.Models;

using DotNetApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<WorksContext>(opt =>
    opt.UseInMemoryDatabase("WorksList"));
builder.Services.AddDbContext<aboutMeContext>(opt =>
    opt.UseInMemoryDatabase("aboutMeList"));
builder.Services.AddDbContext<BlogContext>(opt =>
    opt.UseInMemoryDatabase("BlogList"));
builder.Services.AddDbContext<ClientsContext>(opt =>
    opt.UseInMemoryDatabase("ClientsList"));
builder.Services.AddDbContext<DataDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
