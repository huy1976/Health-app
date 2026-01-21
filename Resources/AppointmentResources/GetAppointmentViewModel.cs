using HealthyApp.Domain.Appointments;
using HealthyApp.Domain.Doctors;
using HealthyApp.Domain.Patients;
using HealthyApp.Resources.DoctorResources;
using HealthyApp.Resources.PatientResources;

namespace HealthyApp.Resources.AppointmentResources;

public class GetAppointmentViewModel
{
    public GetDoctorProfileViewModel doctor { get; set; }

    public Patientprofile patient { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Estatus Status { get; set; }
    public string? Note { get; set; }
    public GetAppointmentViewModel(string doctorId, string patientId, DateTime appointmentDate, Estatus status, string? note)
    {
 
        AppointmentDate = appointmentDate;
        Status = status;
        Note = note;
    }
}
