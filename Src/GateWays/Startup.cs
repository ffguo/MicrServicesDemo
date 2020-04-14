using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using IdentityServer4.AccessTokenValidation;

namespace GateWays
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot()
                    .AddConsul();

            services.AddAuthentication()
                .AddIdentityServerAuthentication(ProjectConfig.IdentityServer.AuthenticationScheme, options =>
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelot();
        }
    }
}
