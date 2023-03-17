using BusinessLogic.Interfaces;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Practic_Api_1.Models;
using Microsoft.OpenApi.Models;
using BusinessLogic.Services; 

namespace Practic_Api_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<WebShopContext>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: "Server=DESKTOP-MSIQDOT;Database=WebShop; Integrated Security=SSPI"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}