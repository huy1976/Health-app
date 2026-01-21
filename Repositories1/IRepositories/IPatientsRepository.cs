using HealthyApp.Domain.Patients;

namespace HealthyApp.Repositories1.IRepositories;

public interface IPatientsRepository
{
    void AddPatient(Patient patient);
    void RemovePatient(Patient patient);
    void UpdatePatient(Patient patient);
    Task<Patient?> GetPatientById(string patientId);
}
