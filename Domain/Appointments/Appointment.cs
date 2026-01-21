using HealthyApp.Domain.Doctors;
using HealthyApp.Domain.Patients;

namespace HealthyApp.Domain.Appointments
{
    public class Appointment
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Appointment()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

        public string AppointmentId { get; set; } = Guid.NewGuid().ToString();
        public string DoctorId { get; private set; } = string.Empty;
        public Doctor Doctor { get; set ; }
        public string PatientId { get; private set; } = string.Empty;
        public Patient Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Estatus Status { get; set; }
        public string? Note { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Appointment(string doctorId, string patientId, DateTime appointmentDate, Estatus status, string? note)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentDate = appointmentDate;
            Status = status;
            Note = note;
        }
        public void UpdateAppointmentDate(DateTime appointmentDate)
        {
            AppointmentDate = appointmentDate;
        }
        public void UpdateDoctorId(string doctorId)
        {
            DoctorId = doctorId;
        }
        public void UpdatePatientId(string patientId)
        {
            PatientId=patientId;
        }
        public void UpdateNote(string note)
        {
            Note = note;
        }
        public void UpdatetStatus(Estatus status)
        {
            Status = status;
        }
    }
}
