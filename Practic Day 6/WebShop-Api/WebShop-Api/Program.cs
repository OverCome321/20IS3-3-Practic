using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.OpenApi.Models;
using Domain.Interfaces;
using DataAccess.Wrapper;
using BussinesLogic.Services;

namespace WebShop_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WebShopContext>(
                optionsAction: options => options.UseSqlServer(connectionString: "Server=lab116-p;Database=WebShop;User Id=sa;Password=12345;"));

            builder.Services.AddScoped<Domain.Interfaces.IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            // Add services to the container.

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