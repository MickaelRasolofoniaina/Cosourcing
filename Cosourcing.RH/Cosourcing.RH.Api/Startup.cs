
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Cosourcing.RH.Bootstrapper;
using Microsoft.Extensions.Configuration;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

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
        var allowedOrigins = new HashSet<string>(Configuration.GetValue<string[]>("AllowedHosts") ?? Array.Empty<string>());

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
                Title = "Hello Elton Cnam Services API",
                Version = "v1"
            });
        });

        //FirebaseApp.Create(new AppOptions
        //{
        //    Credential = GoogleCredential.FromFile(
        //          Path.Combine(Directory.GetCurrentDirectory(),
        //              @"AppData/firebase/hello-elton-firebase-adminsdk-4cr8q-9d7aa35a6b.json"))
        //});
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

