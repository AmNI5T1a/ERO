using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;

using System.Linq;

using Data.Interfaces;
using Data.Models;
using Controllers;


namespace ERO
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers();

            services.AddTransient<IGetAllCars, CarsController>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LuxuryCars",
                    Description = "An ASP.NET Core Web API for managing luxury cars back-end"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( options => 
                                    {
                                        options.SwaggerEndpoint(@$"/swagger/v1/swagger.json", "v1");
                                        // Comment this stroke 1 below to avoid DarkMode in Swagger UI
                                        options.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                                        options.RoutePrefix = string.Empty;
                                    });
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
