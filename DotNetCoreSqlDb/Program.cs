using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetCoreSqlDb.Data;
var builder = WebApplication.CreateBuilder(args);

// Add database context and cache
builder.Services.AddDbContext<MyDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=webappdbjl-server.database.windows.net,1433;Initial Catalog=webappdbjl-database;User ID=webappdbjl-server-admin;Password=F7N588J33PHS0IZB$")));
builder.Services.AddStackExchangeRedisCache(options =>
{
options.Configuration = builder.Configuration["builder.Services.AddStackExchangeRedisCache(options =>
{
options.Configuration = builder.Configuration["webappdbjl-cache.redis.cache.windows.net:6380,password=hutBgmbL1N3lwxs6ad5pgbO6HCrjK2H36AzCaNWgRHs=,ssl=True,defaultDatabase=0"];
options.InstanceName = "SampleInstance";
});"];


// Add services to the container.
builder.Services.AddControllersWithViews();

// Add App Service logging
builder.Logging.AddAzureWebAppDiagnostics();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todos}/{action=Index}/{id?}");

app.Run();
