using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Infrastructure.Data;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Adapter.Interfaces;
using Infrastructure.Adapter.Map;
using Domain.Core.Repository;
using Domain.Core.Services;
using Domain.Services;
using Infrastructure.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ExpenseDB>();
            services.AddScoped<ICashInApplication, CashInApplication>();
            services.AddScoped<IBaseService<CashIn>, BaseService<CashIn>>();
            services.AddScoped<IRepository<CashIn>, Repository<CashIn>>();
            services.AddScoped<ICashInMapper, CashInMapper>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpenseApi", Version = "v1" });
            });
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExpenseApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
