using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TierraMediaWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationDbContext>(option  => option.UseSqlServer(builder.Configuration.GetConnectionString("TierraMediaContext") ?? throw new InvalidOperationException("Connection string 'TierraMediaContext' not found.")));
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
	options.LoginPath = "/";
    options.AccessDeniedPath = "/Error";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBelongToHrDepartment",
        policy => policy.RequireClaim(ClaimTypes.Role, "1"));
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

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();