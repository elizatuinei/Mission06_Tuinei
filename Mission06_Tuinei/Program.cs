using Microsoft.EntityFrameworkCore;
using Mission06_Tuinei.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Sets up the service to be able to use the database
builder.Services.AddDbContext<MovieFormContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:FirstConnection"]);
});

var app = builder.Build();
// in development you WANT to see the error, but if you're not in development mode
// it will show a ncie error
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
