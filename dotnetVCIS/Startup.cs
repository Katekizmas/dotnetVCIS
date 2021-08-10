using dotnetVCIS.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

//using Newtonsoft.Json.Serialization;

namespace dotnetVCIS
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
            var PostgreSQLConnectionConfiguration = new PostgreSQLConfiguration(Configuration.GetConnectionString("VeterinarijaAppCon"));
            services.AddSingleton(PostgreSQLConnectionConfiguration);

            //services.AddSingleton<ISeimininkaiRepository, SeimininkaiRepository>(); // or AddScoped?
            services.AddScoped<ISeimininkaiRepository, SeimininkaiRepository>();

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false; // .Net will stop removing async sufix's in run time
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetVCIS", Version = "v1" });
            });

            services.AddHealthChecks()
                .AddNpgSql(
                PostgreSQLConnectionConfiguration.ConnectionString,
                name: "PostgreSQL",
                timeout: TimeSpan.FromSeconds(5),
                tags: new [] { "ready" }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*//Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetVCIS v1"));
            }

            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/HealthChecks/ready", new HealthCheckOptions { // Check if DATABASE is up and running
                    Predicate = (check) => check.Tags.Contains("ready"),
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonSerializer.Serialize(
                            new
                            {
                                status = report.Status.ToString(),
                                checks = report.Entries.Select(entry => new
                                {
                                    name = entry.Key,
                                    status = entry.Value.Status.ToString(),
                                    exception = entry.Value.Exception != null ? entry.Value.Exception.Message : "none",
                                    duration = entry.Value.Duration.ToString()
                                })
                            }
                        );
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });
                endpoints.MapHealthChecks("/HealthChecks/live", new HealthCheckOptions { // Check if API services is up and running
                    Predicate = (_) => false
                });
            });
        }
    }
}
