using HealthyApp.Persistence;

namespace HealthyApp.Repositories;

public class BaseRepositories1
{
    protected ApplicationDbContext _context;
    public BaseRepositories1(ApplicationDbContext context)
    {
        _context = context;
    }
}
