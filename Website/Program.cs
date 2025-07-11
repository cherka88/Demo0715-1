using Service.Interface;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Db連線字串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// DB連線服務
builder.Services.AddDbContext<DemoDbContext>(
        options =>
        {
            options.UseSqlServer(connectionString);
        });

// 註冊 ICustomerService 服務
builder.Services.AddScoped<ICustomerService, CustomerService>();
// 註冊 IProductService 服務
builder.Services.AddScoped<IProductService, ProductService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
