using HealthyApp.Domain.Patients;
using HealthyApp.Persistence;
using HealthyApp.Repositories;
using HealthyApp.Repositories1.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Repositories1.Implementations;

public class PatientsRepository : BaseRepositories1, IPatientsRepository
{
    public PatientsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void AddPatient(Patient patient)
    {
        _context.Patients.Add(patient);
    }

    public async Task<Patient?> GetPatientById(string patientId)
    {
        var PatientToGet = await _context.Patients.Include(p=>p.Appointments).FirstOrDefaultAsync(a => a.PatientId == patientId);
        
        return PatientToGet;
    }
    public void RemovePatient(Patient patient)
    {
        _context.Remove(patient);
    }

    public void UpdatePatient(Patient patient)
    {
       _context.Update(patient);
    }
}
