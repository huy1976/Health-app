using HealthyApp.Domain.Appointments;

namespace HealthyApp.Repositories_of_Appointment.IRepositories;

public interface IAppointmentRepositories
{
    void AddAppointment(Appointment appointment);
    void RemoveAppointment(Appointment appointment);
    void UpdateAppointment(Appointment appointment);
    Task<Appointment?> GetAppointmentById(string appointmentId);
}
