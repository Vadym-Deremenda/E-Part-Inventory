using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.Mappins;
using E.Part.Inventory.WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//Add Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Add DB Context
builder.Services.AddDbContext<EPartInventoryContext>(options=>options.UseSqlite("Data Source=EPartInventoryDb.sql"));
//Add Services
builder.Services.AddScoped<OrderServices>();
builder.Services.AddScoped<ProductServices>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
