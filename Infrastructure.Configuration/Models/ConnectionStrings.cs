namespace Infrastructure.Configuration.Models;

public class ConnectionStrings
{
    public string TechDocContext { get; set; }

    public ConnectionStrings()
    {
    }

    public ConnectionStrings(string techDocContext)
    {
        TechDocContext = techDocContext;
    }
}