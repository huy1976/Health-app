using HealthyApp.Domain.Doctors;
using HealthyApp.Persistence;
using HealthyApp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Repositories.Implementations;

public class DoctorRepository : BaseRepositories, IDoctorRepository
{
    public void AddDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public async Task<Doctor?> GetDoctorById(string doctorId)
    {
        var doctorToGet =await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == doctorId);
        return doctorToGet;
    }

    public void RemoveDoctor(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
    }

    public void UpdateDoctor(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
    }
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {

    }

}
