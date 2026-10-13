
using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskFlow.Application.Common.Interface;
using TaskFlow.Application.Repositories;
using TaskFlow.Application.Service;
using TaskFlow.Insfrastructure.Caching;
using TaskFlow.Insfrastructure.Data;
using TaskFlow.Insfrastructure.Identity;
using TaskFlow.Insfrastructure.Repository;
using TaskFlow.Insfrastructure.Service;
using TaskFlow.WebApi.Extensions;

namespace TaskFlow.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }).AddMvc();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddScoped<IProjectTaskService, ProjectTaskService>();
            builder.Services.AddDbContext<TenantDbContext>(Options =>
            Options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
            builder.Services
                .AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<TenantDbContext>().  
                AddSignInManager().AddDefaultTokenProviders();

            builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<ICacheService, ReddisCacheService>();
            builder.Services.AddScoped<ITenantService, TenantService>();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration
                ["Redis:ConnectionStrings"];
            });


            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(Options =>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],

                        ValidAudience = builder.Configuration["JWT:Audiennce"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("JWT:Key"))
                    };
                });
                

            var app = builder.Build();

            app.UseGlobalExceptionHandler();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
           


            app.MapControllers();

            app.Run();
        }
    }
}
