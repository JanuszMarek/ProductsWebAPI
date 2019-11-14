using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductsWebAPI.Infrastructure;
using Repository;
using Repository.Interfaces;

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
            //register Db Context
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration["ConnectionString"]));

            //register repository DI
            services.AddScoped<IProductRepository, ProductRepository>();

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
