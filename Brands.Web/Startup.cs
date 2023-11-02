using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brands.Core.Services;
using Brands.Core.Services.Interfaces;
using Brands.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Brands.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddHttpClient("Beh", client =>
            {
                client.BaseAddress = new Uri(Core.DomainName.MyDomain.Domain);
            });

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "DynamicAuthentication";
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddPolicyScheme("DynamicAuthentication", "Bearer or Cookies", options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                    if (authHeader?.StartsWith("Bearer ") == true)
                    {
                        return JwtBearerDefaults.AuthenticationScheme;
                    }
                    return CookieAuthenticationDefaults.AuthenticationScheme;
                };
            }).AddCookie(options =>
            {
                options.LoginPath = "/Admin/Login";
                options.LogoutPath = "/Logout";
                options.Cookie.Name = "Auth.Coo";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Core.DomainName.MyDomain.Domain,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifyTopLearn"))
                };
            });

            #endregion

            #region  DataBase Context

            services.AddDbContext<BrandsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BrandsConnection"));
            });

            #endregion

            #region Dependency Injection

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            #endregion

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .Build();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.ToString().ToLower().StartsWith("/brands images"))
                {
                    var callingUrl = context.Request.Headers["Referer"].ToString();
                    if (callingUrl != "" 
                    && (callingUrl.StartsWith(Brands.Core.DomainName.MyDomain.Domain)
                    || callingUrl.StartsWith(Brands.Core.DomainName.MyDomain.My_2nd_DomainName)
                    || callingUrl.StartsWith(Brands.Core.DomainName.MyDomain.My_3th_DomainName)))
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        context.Response.Redirect("/Login");
                    }
                }
                else
                {
                    await next.Invoke();
                }


            });

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

            app.UseCors("EnableCors");

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
