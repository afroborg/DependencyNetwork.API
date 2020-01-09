using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Azure;
using DpcNtwk.API.Data;
using Microsoft.EntityFrameworkCore;
using DpcNtwk.API.Data.Repos;
using AutoMapper;

namespace DpcNtwk.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors();
            services.AddScoped<IMainRepository, MainRepository>();
            services.AddAutoMapper(typeof(Startup));
            //services.AddAzureClients(builder =>
            //{
            //    builder.AddBlobServiceClient(_configuration["ConnectionStrings:DefaultEndpointsProtocol=https;AccountName=dpcntwkapstorage;AccountKey=nJVxajepALkpeG9YJc7JWFBdb3V7poL6Xc0AdQZzJ2UnNTi4rR+Y7appptqkJFMZqdHO+2EJk1Uv+eprcO2HNA==;EndpointSuffix=core.windows.net"]);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
