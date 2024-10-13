using Infrastructure.Configuration.Abstractions;
using Infrastructure.Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.TechDoc.Configuration;

public class DbContextRegister : IRegisterServices
{
    // private readonly ConnectionStrings _connectionStrings;
    //
    // public DbContextRegister(ConnectionStrings connectionStrings)
    // {
    //     _connectionStrings = connectionStrings;
    // }

    public DbContextRegister()
    {
    }

    public void Register(IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();
        var connectionStrings = sp.GetService<ConnectionStrings>();
        services.AddDbContext<TechDocContext>(options => options.UseSqlServer(connectionStrings.TechDocContext));
    }
}