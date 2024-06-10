using Microsoft.EntityFrameworkCore;
using TugasAkhir_VsCode.Data;
using TugasAkhir_VsCode.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    #pragma warning disable CS8604 // Possible null reference argument.
    o.UseMySQL(builder.Configuration.GetConnectionString("mysql"));
    #pragma warning restore CS8604 // Possible null reference argument.
});

builder.Services.AddAuthentication("CookieAuth")
	.AddCookie("CookieAuth", o =>
	{
		o.LoginPath = "/Login/Index";
		o.AccessDeniedPath = "/Login/Index";
	});

    
builder.Services.AddTransient<FileService>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapAreaControllerRoute(
	name: "AreaOwner",
	areaName: "Owner",
	pattern: "Owner/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
	name: "AreaAdmin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
