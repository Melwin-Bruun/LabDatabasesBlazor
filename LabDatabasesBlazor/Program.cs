using LabDatabasesBlazor.Components;
using LabDatabasesBlazor.Model;
using LabDatabasesBlazor.Service;

namespace LabDatabasesBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            
            // Buld up serive and contation to the database
            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("Lab4MongoBlazorDB"));

            builder.Services.AddSingleton<BookService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
