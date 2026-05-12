using BLL.Services;
using DAL.EF;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EventManagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EventDbContext ")));

builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<AttendeeService>();
builder.Services.AddScoped<OrganizerService>();
builder.Services.AddScoped<EventHubService>();

builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<RoleRepo>();
builder.Services.AddScoped<ReviewRepo>();
builder.Services.AddScoped<EventRepo>();
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<BookingRepo>();

builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session expiration
    options.Cookie.HttpOnly = true; // Prevent JavaScript access
    options.Cookie.IsEssential = true; // GDPR compliance
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession(); // Enable session middleware

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EventHub}/{action=Registration}/{id?}")
    .WithStaticAssets();


app.Run();
