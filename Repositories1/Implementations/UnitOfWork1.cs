using HealthyApp.Persistence;
using HealthyApp.Repositories.IRepositories;

namespace HealthyApp.Repositories.Implementations;

public class UnitOfWork1 :IUnitOfWork1
{
    protected ApplicationDbContext _context;

    public UnitOfWork1(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CompleteAsync()
    {
        await _context.SaveChangesAsync();
        return true;
    }
}
