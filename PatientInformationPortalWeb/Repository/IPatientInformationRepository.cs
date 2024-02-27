using Microsoft.AspNetCore.Identity.UI.Services;
using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public interface IPatientInformationRepository
    {
        Task<List<PatientInformation>> GetAllPatientInformation();
        Task<PatientInformation> GetPatientInformationById(int id);
        Task AddPatient(PatientInformation patientInformation);
        Task UpdatePatient(PatientInformation patientInformation);

        Task DeletePatient(int id);

    }
}
