using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
	public interface IDiseaseInformationRepository
	{
       Task<List<DiseaseInformation>> GetAllDiseaseInformation();
    }
}
