using Microsoft.EntityFrameworkCore;
using OnePieceTCGResultsApi.Entities;

namespace OnePieceTCGResultsApi.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services;
    }
}