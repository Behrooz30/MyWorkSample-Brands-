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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/Admin/Login";
                options.LogoutPath = "/Logout";
                options.Cookie.Name = "Auth.Coo";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

            });
            #endregion

            #region  DataBase Context
            services.AddDbContext<BrandsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BrandsConnection"));
            }
          );
            #endregion

            #region Dependency Injection
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            #endregion

            //The below block is the second authentication configuration in this startup file that the first is
            //the predomenent configuration and below configuration is only for show that we can use it.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,   //This is meaning , token should authenticate in server side.
                    ValidateAudience = false,   //This is meaning , token should not authenticate in client side.
                    ValidateLifetime = true,    //This is meaning , token will be expirable.
                    ValidateIssuerSigningKey = true,  //This is meaning , token should authenticate.
                    ValidIssuer = Core.DomainName.MyDomain.Domain,   //In hear I defined server.
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifyTopLearn"))
                            //In above line I determined a key for encryption.
                };
            });


            //The below block configures Cross-Origin Resource Sharing (CORS) for us.
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
