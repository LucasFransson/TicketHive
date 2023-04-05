using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data.Databases;
using TicketHive.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringUser = builder.Configuration.GetConnectionString("UserDbConnection") ?? throw new InvalidOperationException("Connection string 'UserDbConnection' not found.");
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionStringUser));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var connectionStringApp = builder.Configuration.GetConnectionString("AppDbConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStringApp));

//builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddDefaultIdentity<UserModel>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();

//builder.Services.AddIdentityServer()
//    .AddApiAuthorization<UserModel, UserDbContext>();
builder.Services.AddIdentityServer()
    .AddApiAuthorization<UserModel, UserDbContext>(options =>
    {
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
    });

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
