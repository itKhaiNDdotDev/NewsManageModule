using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NewsManageModule.Data.EF;
using NewsManageModule.Data.Entities;
using NewsManageModule.Services.Catalog.Posts;
using NewsManageModule.Services.Catalog.Topics;
using NewsManageModule.Services.Common;
using NewsManageModule.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManageModule.BackendAPI
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
            services.AddDbContext<NMMDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("NMMDb")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //DI
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<NMMDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IPublicPostService, PublicPostService>();
            services.AddTransient<IManagePostService, ManagePostService>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITopicService, TopicService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger - News Manage Module API -Khai.ND", Version = "v1" });
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer Sheme. \r\n\r\n
                            Enter 'Bearer[SPACE]' and then your token in the textinput below. \r\n\r\n
                            Example: 'Bearer 123456defabc' ",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    In = "header",
                //    Description = "Please enter JWT with Bearer into field",
                //    Name = "Authorization",
                //    Type = "apiKey"
                //});
                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                //    {
                //        "Bearer",
                //        Enumerable.Empty < string > ()
                //    },
                //});
            });

            //string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            //string sKey = Configuration.GetValue<string>("Tokens:Key");
            //byte[] sKeyBytes = System.Text.Encoding.UTF8.GetBytes(sKey);
            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = issuer,
            //            ValidateAudience = true,
            //            ValidAudience = issuer,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ClockSkew = System.TimeSpan.Zero,
            //            IssuerSigningKey = new SymmetricSecurityKey(sKeyBytes)
            //        };
            //    });

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            //app.UseAuthori
            //??

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger News Manage Module API v1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
