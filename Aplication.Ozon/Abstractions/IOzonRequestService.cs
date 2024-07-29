using Aplication.Ozon.Models;

namespace Aplication.Ozon.Abstractions;

public interface IOzonRequestService
{
    public Task<IEnumerable<OzonItem>?> FindPart(string searchString);
}