using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Models.Dtos;
using OnePieceTCGResultsApi.Models.Validators;

namespace OnePieceTCGResultsApi.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();
        services.AddScoped<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
        return services;
    }
}