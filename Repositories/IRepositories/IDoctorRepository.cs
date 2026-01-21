using HealthyApp.Domain.Doctors;

namespace HealthyApp.Repositories.IRepositories;

public interface IDoctorRepository
{
    void AddDoctor(Doctor doctor);
    void RemoveDoctor(Doctor doctor);
    void UpdateDoctor(Doctor doctor);
    Task<Doctor?> GetDoctorById(string doctorId);
}
