using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieFinder.Data;
using MovieFinder.Models;
using MovieFinder.Services.DataServices;
using MovieFinder.Services.ImageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieDbProvider, MovieDbProvider>();
builder.Services.AddScoped<IImageProvider, ImageProvider>();
builder.Services.AddDbContext<MovieFinderDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));

builder.Services.AddIdentity<User, IdentityRole<int>>(options => { 
options.SignIn.RequireConfirmedPhoneNumber = false;
options.SignIn.RequireConfirmedAccount = false;
options.SignIn.RequireConfirmedEmail = false;
options.Password.RequiredLength = 3;
options.Password.RequiredUniqueChars = 0;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequireDigit = false;
options.Password.RequireLowercase = false;
options.Password.RequireUppercase = false;

    }).AddRoles<IdentityRole<int>>().AddEntityFrameworkStores<MovieFinderDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/User/Login");
    options.LogoutPath = new PathString("/User/Logout");
    options.AccessDeniedPath = new PathString("/User/AccessDenied");
}
    );


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
//app.UseMiddleware<CurrentUserMiddleware>();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

    );



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
