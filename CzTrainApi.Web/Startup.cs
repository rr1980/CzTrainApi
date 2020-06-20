using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using CzTrainApi.Apis.Katalog.Core;
using CzTrainApi.Apis.Token;
using CzTrainApi.Db;
using CzTrainApi.Services;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CzTrainApi.Web
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
            var tokenControllerAssembly = typeof(TokenController).Assembly;
            services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(tokenControllerAssembly));

            

            services.AddDbContext<DatenbankContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null);
                    builder.MigrationsAssembly("CzTrainApi.Db");
                });

                //options.EnableSensitiveDataLogging();
            });
           

            services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IAnredeKatalogService, AnredeKatalogService>();
            services.AddKatalog();

            services.AddControllers();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policyBuilder => {
                    policyBuilder.RequireClaim(ClaimTypes.Role, "Admin");
                });

                options.AddPolicy("NutzerPolicy", policyBuilder => {
                    policyBuilder.RequireClaim(ClaimTypes.Role, "Admin", "Nutzer");
                });

                options.AddPolicy("KatalogLesenPolicy", policyBuilder => {
                    policyBuilder.RequireClaim(ClaimTypes.Role, "Admin", "Nutzer");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Version = "v1",
                    Title = "CzTrainApi",
                    //Description = "A simple example ASP.NET Core Web API",
                    Description = "Token: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIwIiwianRpIjoiMzlhMjAwYWQtNDVjNS00N2EwLTk4YzQtYmEzYjNkZmYwM2I2IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiTnV0emVyIiwibmJmIjoxNTkyNjc2MDk3LCJleHAiOjE1OTI2ODMyOTcsImlzcyI6ImRramFzZGFqc2prMzkwMjA5MzgyMTA5Mzhsa3NhamRsamFzbGtqIiwiYXVkIjoiZGtqYXNkYWpzamszOTAyMDkzODIxMDkzOGxrc2FqZGxqYXNsa2oifQ.gPM-J5q2_nZTY0Bd0RnML9aanDV3sCcr2r7sa2wwt8I"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var xmlFile1 = $"{typeof(LoginRequestVM).Assembly.GetName().Name}.xml";
                var xmlPath1 = Path.Combine(AppContext.BaseDirectory, xmlFile1);
                c.IncludeXmlComments(xmlPath1);

                var xmlFile2 = $"{typeof(TokenController).Assembly.GetName().Name}.xml";
                var xmlPath2 = Path.Combine(AppContext.BaseDirectory, xmlFile2);
                c.IncludeXmlComments(xmlPath2);

                var xmlFile3 = $"{typeof(TokenController).Assembly.GetName().Name}.xml";
                var xmlPath3 = Path.Combine(AppContext.BaseDirectory, xmlFile3);
                c.IncludeXmlComments(xmlPath3);
            });

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:Secret"]);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.SaveToken = true;
                    jwtOptions.RequireHttpsMetadata = true;
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["ApplicationSettings:Issuer"].ToString(),
                        ValidAudience = Configuration["ApplicationSettings:Audience"].ToString(),
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        SaveSigninToken = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CzTrainApi V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

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
