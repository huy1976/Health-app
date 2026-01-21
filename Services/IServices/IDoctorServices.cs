using HealthyApp.Resources.DoctorResources;

namespace HealthyApp.Services.IServices;

public interface IDoctorServices
{
    Task<bool> AddDt(string doctorName, string phoneNumber, string hospitalName, string location);
    Task<bool> RemoveDoctor(string doctorId);
    Task<bool> UpdateDoctor(string doctorId,string? doctorName, string? phoneNumber, string? hospitalName, string? location);
    Task<GetDoctorProfileViewModel> GetDoctorProfile(string doctorId);
}
