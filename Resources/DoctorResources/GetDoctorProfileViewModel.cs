namespace HealthyApp.Resources.DoctorResources;

public class GetDoctorProfileViewModel
{
    public string HospitalName { get; private set; } = string.Empty;
    public string DoctorFullName1 { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Locationn { get; private set; } = string.Empty;
    public GetDoctorProfileViewModel(string hospitalName, string doctorFullName, string phoneNumber, string locationn)
    {
        HospitalName = hospitalName;
        DoctorFullName1 = doctorFullName;
        PhoneNumber = phoneNumber;
        Locationn = locationn;
    }
}
