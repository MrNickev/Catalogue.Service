using Aplication.Ozon.Abstractions;
using Aplication.Ozon.Services;
using Application.Common.Abstractions;
using Infrastructure.Configuration.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Aplication.Ozon.Configuration;

public class OzonRegisterServices : IRegisterServices
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<ISearcherService, OzonSearchService>();
        services.AddScoped<IOzonRequestService, OzonApiService>();
    }
}