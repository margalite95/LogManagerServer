using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALContracts;
using LoggerManagerDBDAL;
using LoggerServiceFactory;
using LogManagerContract.Interfaces;
using LogToDBService;
using LogToFileService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OracleDAL;

namespace LogManager
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
            IServiceProvider _serviceProvider;
            services.AddTransient<IInfraDAL, InfraDAL>();
            services.AddTransient<LogToDBServiceImpl>();
            services.AddTransient<LogToFileServiceImpl>();
            services.AddTransient<ILoggerManagerDBDAL, LoggerManagerDBDALImpl>();


            services.AddTransient<ILoggerServiceFactory>(provider =>
                new LoggerServiceFactoryImpl(provider));
            _serviceProvider = services.BuildServiceProvider();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }
         );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
