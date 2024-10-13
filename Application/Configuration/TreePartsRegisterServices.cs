using Application.Abstractions;
using Application.Services;
using Infrastructure.Configuration.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public class TreePartsRegisterServices : IRegisterServices
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<IVehicleSearchService, TechDocVehicleSearchService>();
    }
}