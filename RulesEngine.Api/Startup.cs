using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RulesEngine.Process.Interface;
using RulesEngine.Process;

namespace RulesEngine.Api
{
    public class Startup : StartupBase
    {
        /// <summary>
        /// The environment where the app is hosted
        /// </summary>
        public IWebHostEnvironment Environment { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            Environment = hostingEnvironment; 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                //options.Conventions.Add(new CommaSeparatedQueryStringConvention());
            }).AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rules Engine Service",
                    Version = "v1",
                    Description = "Service for managing Business Rules Engine",
                });
            });
            services.AddScoped<IMembershipProcess, MembershipProcess>();
            services.AddScoped<IProductProcess, ProductProcess>();
            services.AddScoped<IBookProcess, BookProcess>();
            services.AddScoped<ISendEmailProcess, SendEmailProcess>();
            services.AddScoped<IAgentPaymentProcess, AgentPaymentProcess>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Rules Engine Service");
                c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
