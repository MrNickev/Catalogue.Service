using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration.Abstractions;

public interface IRegisterServices
{
    public void Register(IServiceCollection services);
}