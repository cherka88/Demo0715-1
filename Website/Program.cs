﻿using Microsoft.AspNetCore.Identity;

using Service.Interface;
using Service.Services;

using Website.Data;

var builder = WebApplication.CreateBuilder(args);

// Db連線字串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// DB連線服務
builder.Services.AddDbContext<DemoDbContext>(
        options =>
        {
            options.UseSqlServer(connectionString);
        });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 註冊 ICustomerService 服務
builder.Services.AddScoped<ICustomerService, CustomerService>();
// 註冊 IProductService 服務
builder.Services.AddScoped<IProductService, ProductService>();
// 註冊 IOrderService 服務
builder.Services.AddScoped<IOrderService, OrderService>();
// 註冊 ISupplierService 服務
builder.Services.AddScoped<ISupplierService, SupplierService>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Checking for default user 'test'.");
    var user = await userManager.FindByNameAsync("test");
    if (user == null)
    {
        logger.LogInformation("Default user 'test' not found. Creating new user.");
        user = new IdentityUser { UserName = "test", Email = "test@example.com", EmailConfirmed = true };
        var result = await userManager.CreateAsync(user, "Test_12345");
        if (result.Succeeded)
        {
            logger.LogInformation("Default user 'test' created successfully.");
        }
        else
        {
            logger.LogError("Error creating default user 'test': {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
    else
    {
        logger.LogInformation("Default user 'test' already exists.");
    }
}

app.Run();
