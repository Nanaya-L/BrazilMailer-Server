using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using System.Text.Json.Serialization;

namespace EduzcaServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Handle circular references
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DATABASE CONNECTION
            builder.Services.AddDbContext<DBContext>(option =>
                option.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"), b => b.MigrationsAssembly("Controllers"))
            );

            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PGContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("PGConnection"), b => b.MigrationsAssembly("Controllers"))
            );

            #endregion

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMailerService, MailerService>();


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
