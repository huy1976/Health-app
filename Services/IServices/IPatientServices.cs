using HealthyApp.Resources.DoctorResources;
using HealthyApp.Resources.PatientResources;

namespace HealthyApp.Services.IServices;

public interface IPatientServices
{
    Task<bool> ADDPatient(string patientName, string phoneNumber, string email);
    Task<bool> RemovePatient(string patientId);
    Task<bool> UpdatePatient(string patientId, string? patientName, string? phoneNumber, string? email);
    Task<GetPatientProfileViewModel> GetPatientProfile(string patientId);
   
}
