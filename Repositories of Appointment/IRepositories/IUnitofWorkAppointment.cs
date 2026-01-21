namespace HealthyApp.Repositories_of_Appointment.IRepositories;

public interface IUnitofWorkAppointment
{
    Task<bool> CompleteAsync();
}
