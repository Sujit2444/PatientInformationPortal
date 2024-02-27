using Microsoft.EntityFrameworkCore;
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

        public async Task AddPatient(PatientInformation patientInformation)
        {
            try
            {
                await _applicationDBContext.PatientsInformation.AddAsync(patientInformation);
                await _applicationDBContext.SaveChangesAsync();
            }
            catch (Exception)
            { }
        }

        public Task DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PatientInformation>> GetAllPatientInformation()
        {
           return await _applicationDBContext.PatientsInformation.ToListAsync();
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
