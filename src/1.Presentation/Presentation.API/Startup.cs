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
using Domain.Core.Service;
using Domain.Services;
using Infrastructure.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            //MongoDB
            services.AddSingleton<ExpenseDB>();

            //Applications
            services.AddScoped<ICashOutApplication, CashOutApplication>();
            services.AddScoped<ICashInApplication, CashInApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            //Servies
            services.AddScoped<IBaseService<User>, BaseService<User>>();
            services.AddScoped<ICashInService, CashInService>();
            services.AddScoped<ICashOutService, CashOutService>();
            services.AddScoped<IUserService, UserService>();

            //Mappers
            services.AddScoped<ICashInMapper, CashInMapper>();
            services.AddScoped<ICashOutMapper, CashOutMapper>();
            services.AddScoped<IUserMapper, UserMapper>();

            //Repository
            services.AddScoped<IRepository<User>, Repository<User>>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpenseApi", Version = "v1" });
            });
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers()
                    .AddNewtonsoftJson(opt => 
                            opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //JWT
            var secretKey = Configuration["Jwt:Key"];
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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
