using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.API.Configurations.Extensions;
using Account.BusinessLayer;
using Account.BusinessLayer.Mapping;
using Account.BusinessLayer.Validation;
using Account.DataAccessLayer;
using Account.DTO;
using Account.Entities;
using Account.InfrastructureEF;
using Account.Interfaces.Business;
using Account.Interfaces.Business.Validations;
using Account.Interfaces.DataAccess;
using API.Helper.LoggerService;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog;

namespace Account.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
                .EnableSensitiveDataLogging());




            #region Authentication

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion




            #region Business Implementation

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<ISecurityBusiness, SecurityBusiness>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();

            #endregion




            #region DataAccess Implementation

            services.AddScoped<IPersonDataAccess, PersonDataAccess>();
            services.AddScoped<IUserDataAccess, UserDataAccess>();
            services.AddScoped<IBalanceDataAccess, BalanceDataAccess>();
            services.AddScoped<IUserBalanceDataAccess, UserBalanceDataAccess>();
            
            #endregion




            #region Validation

            services.AddScoped<IPersonValidate, PersonValidate>();
            services.AddScoped<IUserValidation, UserValidation>();

            #endregion


            
            
            #region AutoMapper

            var configMap = new MapperConfiguration(Config => {
                Config.AddProfile<UserInProfile>();
                Config.AddProfile<PersonInProfile>();
                Config.AddProfile<UserOutProfile>();
                Config.AddProfile<PersonOutProfile>();
            });
            var mapper = configMap.CreateMapper();
            services.AddSingleton(mapper);

            #endregion




            services.ConfigureLoggerService();

            services.AddControllers();

            services.AddSwaggerGen(Config =>
            {
                Config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Intelligent Business", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, ILoggerManager logger)
        {
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Intelligent Business");
                });

                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
