using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TierraMediaWeb.Data;
using TierraMediaWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("TierraMediaContext") ?? throw new InvalidOperationException("Connection string 'TierraMediaContext' not found.")));
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/Error";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        policy => policy.RequireClaim(ClaimTypes.Role, ((int)RoleType.Admin).ToString()));
    options.AddPolicy("Client",
        policy => policy.RequireClaim(ClaimTypes.Role, ((int)RoleType.Client).ToString()));
    options.AddPolicy("AdminOrClient", policy =>
    {
        policy.RequireRole(((int)RoleType.Admin).ToString(), ((int)RoleType.Client).ToString());
    });
});
builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();