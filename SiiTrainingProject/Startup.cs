using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiiTrainingProject.Code.AsyncSamples;
using System.Net.Http.Headers;
using SiiTrainingProject.Code.Interfaces;
using SiiTrainingProject.Code.Services;
using Microsoft.AspNetCore.Routing;
using SiiTrainingProject.Code.Routes;

namespace SiiTrainingProject
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
            //Dependency Injection for Filter
            services.AddScoped<IFilterDiagnostics, BasicFilterDiagnostics>();

            services.AddScoped<IRepository, DummyRepository>();

            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));


            //services.AddMvc();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<OperationCancelledExceptionFilter>();
            //});

            services.AddMvc(options =>
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat
                    ("xml", "application/xml");
                options.FormatterMappings.SetMediaTypeMappingForFormat
                    ("js", "application/json");
            })
                .AddXmlSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //  name: "CustomRouteConstraintInline",
                //  template: "Routes/CustomConstraintInline/{day:weekday?}"
                //);

                //routes.MapRoute(
                //  name: "CustomRouteConstraint",
                //  template: "{controller}/{action}/{day?}",
                //  defaults: new { controller = "Routes", action = "CustomConstraint" },
                //  constraints: new { day = new WeekDayConstraint() }
                //);

                //routes.MapRoute(
                //    name: "componentRoute",
                //    template: "{controller=Component}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
