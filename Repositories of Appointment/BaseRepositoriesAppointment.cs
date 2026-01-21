using HealthyApp.Persistence;

namespace HealthyApp.Repositories_of_Appointment;

public class BaseRepositoriesAppointment
{
    protected ApplicationDbContext _context;
    public BaseRepositoriesAppointment(ApplicationDbContext context)
    {
        _context = context;
    }
}
