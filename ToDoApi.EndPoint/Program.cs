using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Microsoft.Extensions.Configuration;
using MediatR;
using Application.ToDo.Commands;
using Application.ToDo.Queries;
using Application.Abstractions;
using Infrastructure.Repositories;
using ToDoApi.EndPoint.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<CreateToDooCommand>

     builder.Services.AddMediatR(typeof(CreateToDooCommand).Assembly);
builder.Services.AddMediatR(typeof(EditToDooCommand).Assembly);
builder.Services.AddScoped<IToDoRepository, ToDoRepositoriy>();
builder.Services.AddMediatR(typeof(GetToDooQuery).Assembly);
//string connection = Configuration["ConnectionString:SqlServer"];

//builder.Services.AddDbContext<DataBaceContext>(option => option.UseSqlServer(connection));

string contectionString = @"server=.; Initial Catalog=ToloList; Integrated Security=True;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaceContext>(option => option.UseSqlServer(contectionString));

builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseCustumExeption();

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
