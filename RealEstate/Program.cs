using Bl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RealestateContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<RealestateContext>();
builder.Services.AddScoped<IResidentialService, ClsResidential>();
builder.Services.AddScoped<ICommercialService, ClsCommercial>();
builder.Services.AddScoped<IIndustrialService, ClsIndustrial>();
builder.Services.AddScoped<IAgriculturalService, ClsAgricultural>();
builder.Services.AddScoped<ITeamService, ClsTeam>();
builder.Services.AddScoped<IClassificationService, ClsClassification>();
builder.Services.AddScoped<IImagesService, ClsImages>();
builder.Services.AddScoped<IAdsServices, ClsAds>();




builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

}).AddEntityFrameworkStores<RealestateContext>().AddDefaultUI();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/LoginUsers/AccessDenied";
    options.Cookie.Name = "Cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
    options.LoginPath = "/LoginUsers/Login";
    //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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


app.MapControllerRoute(
    name: "areas",
    pattern: "{area=exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default2",
    pattern: "/exists/{controller=Home}/{action=Index}/{id?}");









//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;
//try
//{
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    await RealEstate.Seeds.DefaultRoles.SeedRolesAsync(roleManager);
//    await RealEstate.Seeds.DefaultUsers.SeedAdminAsync(userManager);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

app.Run();
