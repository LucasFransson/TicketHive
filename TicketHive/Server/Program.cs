using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Data.Repositories.Implementations;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringUser = builder.Configuration.GetConnectionString("UserDbConnection") ?? throw new InvalidOperationException("Connection string 'UserDbConnection' not found.");
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionStringUser));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionStringApp = builder.Configuration.GetConnectionString("AppDbConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStringApp));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<UserModel, UserDbContext>(options =>
    {
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
    });

// This is needed to authorize methods on an endpoint, [Authorize(Roles = "Admin"]
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
    var context = serviceProvider.GetRequiredService<UserDbContext>();
    var signInManager = serviceProvider.GetRequiredService<SignInManager<UserModel>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    context.Database.Migrate();

    UserModel? defaultUser = signInManager.UserManager.FindByNameAsync("user").GetAwaiter().GetResult();

    if (defaultUser is null)
    {
        defaultUser = new()
        {
            UserName = "user",
            CountryName = "Sweden"
        };

        signInManager.UserManager.CreateAsync(defaultUser, "Password1234!").GetAwaiter().GetResult();
    }

    UserModel? adminUser = signInManager.UserManager.FindByNameAsync("admin").GetAwaiter().GetResult();

    if (adminUser == null)
    {
        adminUser = new()
        {
            UserName = "admin",
            CountryName = "Sweden",
        };

        signInManager.UserManager.CreateAsync(adminUser, "Password1234!").GetAwaiter().GetResult();
    }

    IdentityRole? adminRole = roleManager.FindByNameAsync("Admin").GetAwaiter().GetResult();

    if (adminRole is null)
    {
        adminRole = new()
        {
            Name = "Admin"
        };

        roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
    }

    signInManager.UserManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
