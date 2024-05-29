using Application.Abstractions;
using Application.ToDo.Commands;
using Application.ToDo.Queries;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);   

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddMediatR(typeof(CreateToDooCommand).Assembly);
builder.Services.AddMediatR(typeof(EditToDooCommand).Assembly);
builder.Services.AddMediatR(typeof(ComplateToDooCommand).Assembly);
builder.Services.AddMediatR(typeof(DeleteToDooCommand).Assembly);
builder.Services.AddScoped(typeof(IToDoRepository<>), typeof(ToDoRepositoriy<>));

builder.Services.AddMediatR(typeof(GetToDooQuery).Assembly);
//string connection = Configuration["ConnectionString:SqlServer"];

//builder.Services.AddDbContext<DataBaceContext>(option => option.UseSqlServer(connection));

string contectionString = @"server=.; Initial Catalog=ToloList; Integrated Security=True;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaceContext>(option => option.UseSqlServer(contectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
