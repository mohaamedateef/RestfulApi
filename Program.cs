using Microsoft.EntityFrameworkCore;
using RestfullAPI.Models;
using RestfullAPI.Repositories;

namespace RestfullAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add Db Service to the app and read from appsettings
            builder.Services.AddDbContext<ApiDbContext>((options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            // Add Cors to let outside request to the api
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", cors =>
                {
                    cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}