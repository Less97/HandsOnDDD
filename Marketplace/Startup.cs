using Microsoft.OpenApi.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Marketplace
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x=>x.EnableEndpointRouting = false);
            services.AddSwaggerGen(c => 
                c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "ClassifiedAds",
                Version = "V1"
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassifiedAds V1"));

        }
    }
}
