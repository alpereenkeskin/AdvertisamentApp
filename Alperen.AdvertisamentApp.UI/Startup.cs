using Alperen.AdvertisamentApp.Business.DependencyResolvers.Microsoft;
using Alperen.AdvertisamentApp.Business.Helpers;
using Alperen.AdvertisamentApp.UI.Mappings;
using Alperen.AdvertisamentApp.UI.Models;
using Alperen.AdvertisamentApp.UI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration configuration { get; set; }

        public Startup(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.Cookie.SameSite = SameSiteMode.Strict;
                    opt.Cookie.Name = "DefaultCookie";
                    opt.Cookie.HttpOnly = true;
                    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                });

            services.AddControllersWithViews();
            services.AddDependencies(configuration);
            var profiles = ProfileHelpers.GetProfiles();
            profiles.Add(new UserCreateModelProfile());
            profiles.Add(new AdvertisamentAppUserModelProfile());
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
