
using DebateSphere.BLL;
using DebateSphere.DAL;
using DebateSphere.DAL.Implementations;
using DebateSphere.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebateSphere
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Register the DbContext with the connection string from appsettings.json
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Register DAL and BLL 
            builder.Services.AddScoped<IUserDAL, UserDAL>();
            builder.Services.AddScoped<DebateDAL>();
            builder.Services.AddScoped<ArgumentDAL>();
            builder.Services.AddScoped<VoteDAL>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<DebateService>();
            builder.Services.AddScoped<ArgumentService>();
            builder.Services.AddScoped<VoteService>();

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
