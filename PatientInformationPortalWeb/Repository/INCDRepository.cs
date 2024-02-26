using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public interface INCDRepository
    {
        Task<List<NCD>> GetAllNCDs();
    }
}
