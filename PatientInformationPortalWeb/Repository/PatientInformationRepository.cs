using PatientInformationPortalWeb.Data;
using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public class PatientInformationRepository : IPatientInformationRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public PatientInformationRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public Task AddPatient(PatientInformation patientInformation)
        {
            throw new NotImplementedException();
        }

        public Task DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientInformation>> GetAllPatientInformation()
        {
            throw new NotImplementedException();
        }

        public Task<PatientInformation> GetPatientInformationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePatient(PatientInformation patientInformation)
        {
            throw new NotImplementedException();
        }
    }
}
