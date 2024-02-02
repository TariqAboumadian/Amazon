
using Amazon.Application.Contracts;
using Amazon.Application.Services;
using Amazon.Context;
using Amazon.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Amazon.API
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
            var ConnectionString = builder.Configuration.GetConnectionString("CS") ??
                throw new Exception("No Connection String Was Found");
            builder.Services.AddDbContext<AmazonContext>(option =>
            {
                option.UseSqlServer(ConnectionString);
            });
            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(p =>
                {
                    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("secretkey").Value);
            builder.Services.AddAuthentication().AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey=true,
                    ValidateAudience=false,
                    ValidateIssuer=false
                };
            });
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
