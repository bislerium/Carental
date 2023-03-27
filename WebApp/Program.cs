using Configuration;
using Infrastructure.Persistence;
using Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the containers

builder.Configuration.AddConfiguration();

var s  = builder.Configuration.GetConnectionString("DomainDB");

builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddInfrastructureIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
