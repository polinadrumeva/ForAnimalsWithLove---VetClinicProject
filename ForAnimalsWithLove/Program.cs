using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Infrastructure.Extensions;
using ForAnimalsWithLove.Data.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ForAnimalsWithLoveDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
	{
		options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
		options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
		options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
		options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
		options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
	})
	.AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<ForAnimalsWithLoveDbContext>();

builder.Services.AddAppServices();

builder.Services.AddRecaptchaService();
builder.Services.AddControllersWithViews()
				.AddMvcOptions(op => 
				{ 
					op.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Home/Error/500");
	app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
	app.SeedAdmin("daneva@foranimalswithlove.bg");
}


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
