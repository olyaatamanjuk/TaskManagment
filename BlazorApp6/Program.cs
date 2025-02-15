using BlazorApp6;
using BlazorApp6.Components;
using BlazorApp6.Repository;
using BlazorApp6.Services;
using BlazorApp6.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додати репозиторії
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));
//builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Додати узагальнені сервіси
builder.Services.AddScoped(typeof(IService<>), typeof(BasicService<>));

// Додати специфічний сервіс для Task
//builder.Services.AddScoped<ITaskService, TaskService>();

// Додати UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();