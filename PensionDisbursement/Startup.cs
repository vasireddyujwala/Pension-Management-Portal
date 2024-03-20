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
using Microsoft.OpenApi.Models;
using PensionDisbursement.Models;
using PensionDisbursement.Repository;
using PensionDisbursement.Providers;

namespace PensionDisbursement
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
            services.AddControllers()
         .AddControllersAsServices();
            services.AddControllers();

            services.AddTransient<IPensionerProvider, PensionerProvider>();
            services.AddTransient<IPensionerRepository, PensionerRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Pension Disbursement", Version = "v1" });

            });
         //  services.AddSingleton<PensionerRepository>();
         //   services.AddSingleton<DataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)  
        {
            

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
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Pension Disbursement"); }
            );
        }
    }
}
