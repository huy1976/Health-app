using HealthyApp.Persistence;
using HealthyApp.Repositories.IRepositories;

namespace HealthyApp.Repositories.Implementations;

public class UnitOfWork :IUnitOfWork
{
    protected ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CompleteAsync()
    {
        await _context.SaveChangesAsync();
        return true;
    }
}
