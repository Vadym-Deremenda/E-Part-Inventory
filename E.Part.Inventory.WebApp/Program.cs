using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.IRepository;
using E.Part.Inventory.WebApp.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(ICrudRepository<>),typeof(CrudRepository<>));

builder.Services.AddDbContext<EPartInventoryContext>(options=>options.UseSqlite("Data Source=EPartInventoryDb.sql"));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
