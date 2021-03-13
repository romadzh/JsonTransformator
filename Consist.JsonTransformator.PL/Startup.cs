using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consist.JsonTransformator.BL.DomainObjects.Settings;
using Consist.JsonTransformator.BL.Services;
using Consist.JsonTransformator.BL.Services.Interfaces;
using Consist.JsonTransformator.DAL;
using Consist.JsonTransformator.PL.Middlewares;
using Microsoft.Extensions.Options;

namespace Consist.JsonTransformator.PL
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
            services.Configure<MongoDBConnectionSettings>(Configuration.GetSection(nameof(MongoDBConnectionSettings)));
            services.AddSingleton<IMongoDBConnectionSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDBConnectionSettings>>().Value);

            
            services.AddSingleton<ChildDalService>(); //mongo client should be registered in DI with a singleton service lifetime
            services.AddScoped<IChildService, ChildService>();
            

            services.AddCors();
            services.AddControllers();

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddScoped<IAuthenticationService, JwtAuthenticateService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();
            app.UseRouting();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
