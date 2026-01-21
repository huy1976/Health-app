using HealthyApp.Domain.Appointments;
using HealthyApp.Persistence;
using HealthyApp.Repositories_of_Appointment.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Repositories_of_Appointment.Implementations;

public class AppointmentRepositories : BaseRepositoriesAppointment, IAppointmentRepositories
{
    public AppointmentRepositories(ApplicationDbContext context) : base(context)
    {
    }

    public void AddAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
    }

    public async Task<Appointment?> GetAppointmentById(string appointmentId)
    {
        var appointmentToGet = await _context.Appointments.Include(a=>a.Doctor).Include(a=>a.Patient).FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
        return appointmentToGet;
    }

    public void RemoveAppointment(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
    }

    public void UpdateAppointment(Appointment appointment)
    {
        try
        {
            _context.Appointments.Update(appointment);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.InnerException.Message);
        }
        
            
    }
}
