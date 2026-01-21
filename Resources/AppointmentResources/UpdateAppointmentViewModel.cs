using HealthyApp.Domain.Appointments;

namespace HealthyApp.Resources.AppointmentResources;

public class UpdateAppointmentViewModel
{
    public string AppointmentId { get; set; }
    public string? DoctorId { get; set; } 
    public string? PatientId { get; set; } 
    public DateTime AppointmentDate { get; set; }
    public Estatus Status { get; set; }
    public string? Note { get; set; }
}
