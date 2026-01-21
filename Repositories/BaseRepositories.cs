using HealthyApp.Persistence;

namespace HealthyApp.Repositories;

public class BaseRepositories
{
    protected ApplicationDbContext _context;
    public BaseRepositories(ApplicationDbContext context)
    {
        _context = context;
    }
}
