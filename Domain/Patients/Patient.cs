using HealthyApp.Domain.Appointments;
using System.Collections.Generic;
namespace HealthyApp.Domain.Patients
{
    public class Patient
    {
        public string PatientId { get; private set; }= Guid.NewGuid().ToString(); // Tạo khóa chính (duy nhất)
        public string PatientName { get;private set; }=string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty; 
        public string Email { get; private set; } = string.Empty;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Patient(string patientName, string phoneNumber, string email)
        {
            PatientName = patientName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public Patient()
        {
        }
        public void UpdatePatientName(string patientName)
        {
            PatientName = patientName;      
        }
        public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void UpdateEmail(string email) => Email = email;
    }
    

}