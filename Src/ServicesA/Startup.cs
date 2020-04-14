using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServicesA.Extentions;

namespace ServicesA
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
            services.AddControllers();
            services.AddHealthChecks();
            services.AddConsul();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        //设置令牌的发布者
                        options.Authority = ProjectConfig.IdentityServer.Url;
                        //设置Https
                        options.RequireHttpsMetadata = false;
                        //需要认证的api资源名称
                        options.ApiName = ProjectConfig.ServicesAApi.ApiName;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var consulOptions = app.ApplicationServices.GetRequiredService<IOptions<ConsulServiceOptions>>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path.HasValue && context.Request.Path.Value.ToLower().EndsWith(consulOptions.Value.HealthCheck.ToLower()))
                    {
                        await context.Response.WriteAsync("OK");
                    }
                    else
                    {
                        await next(context);
                    }
                };
            });
            //app.UseHealthChecks(consulOptions.Value.HealthCheck);
            app.UseAuthentication();
            app.UseConsul();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
