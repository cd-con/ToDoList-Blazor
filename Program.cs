using MudBlazor.Services;
using Zavod.Database;
using Microsoft.EntityFrameworkCore;
using Zavod.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();
builder.Services.AddScoped<TaskService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using AppDbContext? ctx = scope.ServiceProvider.GetService<AppDbContext>();
    ctx?.Database.Migrate(); // TODO Possibly add automatic data migration from SQLite MSSQL
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
