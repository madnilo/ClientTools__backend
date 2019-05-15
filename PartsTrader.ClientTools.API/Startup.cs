
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartsTrader.ClientTools.API.Domain;
using PartsTrader.ClientTools.API.Model.DTO;
using PartsTrader.ClientTools.API.Repository;
using PartsTrader.ClientTools.API.Service;
using PartsTrader.ClientTools.API.Validators;

namespace PartsTrader.ClientTools.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string DefaultOrigins = "_defaultOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultOrigins,
                builder =>
                {
                    builder
                    .WithOrigins("http://localhost:3000", "http://localhost:3001", "localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod(); ;
                });
            });

            //services.AddAutoMapper();

            services.AddTransient<IPartsValidator, PartsValidator>();
            services.AddTransient<IPartsService, PartsService>();
            services.AddTransient<IPartsRepository, PartsRepository>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "ClientToolsAPISpec",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "ClientTools_API",
                        Version = "1.0"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Something went wrong. Please contact the administrator.");
                    });
                });
                app.UseHsts();
            }

             AutoMapper.Mapper.Initialize(cfg =>
             {
                 cfg.CreateMap<PartSummary, PartSummaryDTO>();
                 cfg.CreateMap<PartDetails, PartDetailsDTO>();
             });

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint(
                        "/swagger/ClientToolsAPISpec/swagger.json",
                        "ClientTools API");
                    setupAction.RoutePrefix = "";
                });

            app.UseCors(DefaultOrigins);

            app.UseMvc();
        }
    }
}
