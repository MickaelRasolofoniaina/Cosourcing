
using Autofac;
using Microsoft.OpenApi.Models;
using Cosourcing.RH.Bootstrapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Autofac.Core;
using Cosourcing.RH.Services.Auth;

namespace Cosourcing.RH.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var allowedOrigins = new HashSet<string>(Configuration.GetValue<string[]>("AllowedHosts") ?? new string[] {"*"});
        var dbConnectionString = Configuration.GetConnectionString("Db") ?? "";

        services.AddCors(options =>
               options
                    .AddDefaultPolicy(p => p.WithOrigins(allowedOrigins.ToArray())
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cosourcing RH Services API",
                Version = "v1"
            });
        });

        services.ConfigureServices(dbConnectionString);

        var jwtSettings = Configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = key,
                };
            });
        services.AddScoped<AuthService>();
    }

    public void ConfigureContainer(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModules();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cosourcing RH API");
                c.RoutePrefix = string.Empty;
            });

            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
       
    }
}

