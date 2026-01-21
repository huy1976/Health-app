using HealthyApp.Domain.Appointments;
using HealthyApp.Resources.AppointmentResources;

namespace HealthyApp.Services.IServices;

public interface IAppointmentService
{
    Task<bool> AddAppointment( string doctorId, string patientId, DateTime appointmentDate, Estatus status, string note );
    Task<bool> RemoveAppointment(string appointmentId);
    Task<bool> UpdateAppointment(string appointmentId,string? doctorId, string? patientId, DateTime dateTime, Estatus status, string note );
    Task<GetAppointmentViewModel>  GetAppointmentProfile(string appointmentId); 
}
