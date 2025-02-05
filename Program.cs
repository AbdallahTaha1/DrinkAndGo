using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using DrinkAndGo.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                            ?? throw new InvalidOperationException("No connection string was found");
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<IDrinkRepository, DrinkRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();

            builder.Services.AddDbContext<DrinkAndGoContext>(options =>
                    options.UseSqlServer(connectionString));
            
            // Register IHttpContextAccessor
            builder.Services.AddHttpContextAccessor();
            // Add session services
            builder.Services.AddDistributedMemoryCache(); // For storing session data in memory
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true; // Ensure session cookie is accessible only on the server
                options.Cookie.IsEssential = true; // Make session cookies essential
            });
            builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DrinkAndGoContext>();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    DbInitializer.Seed(services);
                }
                catch (Exception ex)
                {
                    // Log errors
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}