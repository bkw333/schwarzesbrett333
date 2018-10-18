using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.controllers;
using Api.Hubs;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            
            Configuration = builder.Build();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builderCors =>
                    {
                        builderCors
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<FeedPostsDbContext>
                (option => option.UseSqlServer(Configuration["database:connection"]));

            var cbuilder = new ContainerBuilder();
            cbuilder.RegisterType<FeedPostDataRepository>().As<IFeedPostDataRepository>();
            cbuilder.Populate(services);
            return new AutofacServiceProvider(cbuilder.Build());


        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseSignalR(routes => { routes.MapHub<MessageHub>("/messageHub"); });
            app.UseMvc();

        }
    }
}
