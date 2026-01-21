using HealthyApp.Domain.Appointments;
using HealthyApp.Domain.Doctors;
using HealthyApp.Domain.Patients;
using HealthyApp.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Persistence;

public class ApplicationDbContext : DbContext // Câu lệnh dùng để tương tác với database
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)  // Cấu thành nên các đối tượng class của bảng trong database
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DoctorEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PatientEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentEntityConfiguration());

    }

    protected ApplicationDbContext()
    {
    }
}
