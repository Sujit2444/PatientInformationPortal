using Microsoft.EntityFrameworkCore;
using PatientInformationPortalWeb.Data;
using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public class DiseaseInformationRepository : IDiseaseInformationRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public DiseaseInformationRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<DiseaseInformation>> GetAllDiseaseInformation()
        {
            return await _applicationDBContext.DiseaseInformation.ToListAsync();
        }
    }
}
