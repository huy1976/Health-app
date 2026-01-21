using HealthyApp.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyApp.Persistence.Context.Configurations;

public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        //Primary Key
        builder.HasKey(p => p.PatientId);

        builder.Property(p => p.PatientId)
            .HasDefaultValueSql("NEWID()");

        builder.Property(p => p.PatientName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Email)
            .HasMaxLength(100);

        // Cấu hình quan hệ 1-n: Patient - Appointments
        //FK
        builder.HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
