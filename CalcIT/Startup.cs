using CalcIT.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CalcIT
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
            services.AddCors();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration["ConnectionString:CalcIt"]));
            services.AddIdentity<ApplicationUser, IdentityRole>(config=>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredLength = 4;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<UserContext>()
            .AddDefaultTokenProviders();
   
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Jwt:JwtIssuer"],
                        ValidAudience = Configuration["Jwt:JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });

                //.AddGoogle(options =>
                //{
                //    IConfigurationSection googleAuthNSection =
                //        Configuration.GetSection("Authentication:Google");

                //    options.ClientId = googleAuthNSection["450061769453-v6v6ng5rhtm3ear4vjp6e6gsmecsd4pr.apps.googleusercontent.com"];
                //    options.ClientSecret = googleAuthNSection["ekOP2tjVKvlYfEfwLEndFoOR"];
                //});
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

           
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication(); 
            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller}/{action=Index}/{id?}");
              });
            
            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

        }
    }
}
