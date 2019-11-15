using AutoMapper;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsWebAPI.ActionFilters;
using ProductsWebAPI.Infrastructure;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;

namespace ProductsWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //disable auto validation, I will use custom
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //register Db Context
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration["ConnectionString"]));

            //custom Validation filters
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ExistValidationFilterAttribute<ProductDto, IProductService>>();

            //register repository DI
            services.AddScoped<IProductRepository, ProductRepository>();

            //register service DI
            services.AddScoped<IProductService, ProductService>();

            //AutoMapper config
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    IExceptionHandlerFeature exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Exception: " + exceptionHandlerFeature.Error.Message);
                });
            });

            app.UseMvc();
        }
    }
}
