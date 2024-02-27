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

        public async Task<PatientInformation> GetPatientInformationById(int id)
        {
            PatientInformation patientInformation = await _applicationDBContext.PatientsInformation.FirstOrDefaultAsync(obj => obj.PatientID == id);
            if (patientInformation != null)
            {
                patientInformation.NCDs = await _applicationDBContext.NCD_Details.Where(ncd => ncd.PatientID == id).ToListAsync();
                patientInformation.Allergies = await _applicationDBContext.Allergies_Details.Where(al => al.PatientID == id).ToListAsync();
            }
            return patientInformation;
        }

        public async Task UpdatePatient(PatientInformation patientInformation)
        {
            PatientInformation patientInformationDB=await _applicationDBContext.PatientsInformation.FindAsync(patientInformation.PatientID);
            if (patientInformationDB!=null)
            {
                var ncdDetails = _applicationDBContext.NCD_Details.Where(obj => obj.PatientID == patientInformationDB.PatientID);
                _applicationDBContext.NCD_Details.RemoveRange(ncdDetails);

                var algDetails = _applicationDBContext.Allergies_Details.Where(obj => obj.PatientID == patientInformationDB.PatientID);
                _applicationDBContext.Allergies_Details.RemoveRange(algDetails);

                patientInformationDB.Name=patientInformation.Name;
                patientInformationDB.EpilepsyStatus=patientInformation.EpilepsyStatus;
                patientInformationDB.DiseaseID=patientInformation.DiseaseID;
                patientInformationDB.Allergies=patientInformation.Allergies;
                patientInformationDB.NCDs = patientInformation.NCDs;
                await _applicationDBContext.SaveChangesAsync();
            }
        }
    }
}
