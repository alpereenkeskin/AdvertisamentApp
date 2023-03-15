using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Business.Mappings.AutoMapper;
using Alperen.AdvertisamentApp.Business.Services;
using Alperen.AdvertisamentApp.Business.ValidationRules;
using Alperen.AdvertisamentApp.DataAccess.Contexts;
using Alperen.AdvertisamentApp.DataAccess.UnitOfWork;
using Alperen.AdvertisamentApp.Dtos;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Alperen.AdvertisamentApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisamentContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceDtoCreateValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceDtoUpdateValidator>();
            services.AddTransient<IValidator<AdvertisamentCreateDto>, AdvertisamentCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisamentUpdateDto>, AdvertisamentUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AdvertisamentUserCreateDto>, AdvertisamentAppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisamentUserUpdateDto>, AdvertisamentAppUserUpdateDtoValidator>();
            services.AddScoped<IAdvertisamentService, AdvertisamentService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisamentAppUserService, AdvertisamentAppUserService>();

        }
    }
}
