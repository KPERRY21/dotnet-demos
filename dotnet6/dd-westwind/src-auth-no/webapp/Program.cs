//using statements added
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Get the connection string.
var connectionString = builder.Configuration.GetConnectionString("WWDB");
// TrainWatchContext class as a DbContext using SQL Server
builder.Services.AddDbContext<Context>(context => 
    context.UseSqlServer(connectionString));
// TrainWatchServices class as a transient service
builder.Services.AddTransient<DbServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
