using Application.Avtomoe.Services;
using Application.Common.Abstractions;
using Infrastructure.Configuration.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Avtomoe.Configuration;

public class AvtomoeRegisterServices : IRegisterServices
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<ISearcherService, AvtomoeSearchService>();
    }
}