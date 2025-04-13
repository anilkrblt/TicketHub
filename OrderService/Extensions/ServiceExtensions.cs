using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Repository;
using OrderService.Repository.Contracts;
using OrderService.Service;
using OrderService.Service.Contracts;

namespace OrderService.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(
                options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()    //   WithOrigins("https://example.com")
                            .AllowAnyMethod()   //   WithMethods("POST", "GET")
                            .AllowAnyHeader() //   WithHeaders("accept", "content-type")

                            .WithExposedHeaders("X-Pagination")); //to enable the client application to read the 
                                                                  //new X-Pagination  header that we’ve added in our action



            });
        public static void ConfigureISSIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();


        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

    }
}