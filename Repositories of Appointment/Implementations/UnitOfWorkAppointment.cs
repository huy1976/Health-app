using HealthyApp.Persistence;
using HealthyApp.Repositories_of_Appointment.IRepositories;

namespace HealthyApp.Repositories_of_Appointment.Implementations;

public class UnitOfWorkAppointment : IUnitofWorkAppointment
{
    protected ApplicationDbContext _context;
    public UnitOfWorkAppointment(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CompleteAsync()
    {
        await _context.SaveChangesAsync();
        return true;
    }
}
