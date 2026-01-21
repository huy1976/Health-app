using HealthyApp.Domain.Appointments;
using System.Collections.Generic;

namespace HealthyApp.Domain.Doctors
{
    public class Doctor
    {

        public string DoctorId { get; private set; }= Guid.NewGuid().ToString();
        public string HospitalName { get; private set; }=string.Empty;
        public string DoctorFullName { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string Locationn { get; private set; } = string.Empty;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Doctor(string doctorFullName, string phoneNumber, string locationn,string hospitalName)
        {
            DoctorFullName = doctorFullName;
            PhoneNumber = phoneNumber;
            Locationn = locationn;
            HospitalName = hospitalName;
        }
        public Doctor()
        {
        }
        public void UpdateDoctorName(string doctorName)
        {
            DoctorFullName = doctorName;
        }
        public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void UpdateHospitalname(string hospitalName) => HospitalName = hospitalName;
        public void UpdateLocation(string location )=> Locationn=location;
    }
}
