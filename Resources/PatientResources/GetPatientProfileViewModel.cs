using HealthyApp.Domain.Appointments;
using HealthyApp.Persistence.Context.Configurations;
using HealthyApp.Resources.AppointmentResources;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;

namespace HealthyApp.Resources.PatientResources;

public class GetPatientProfileViewModel
{
    public string PatientName { get;  set; } = string.Empty;
    public string PhoneNumber { get;  set; } = string.Empty;
    public string Email { get;  set; } = string.Empty;
    public List<GetAppointmentViewModel> Appointments {  get; set; }
    public int AppointmentCount { get; set; }
    public GetPatientProfileViewModel(string patientName, string phoneNumber, string email)
    {
        PatientName = patientName;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}

