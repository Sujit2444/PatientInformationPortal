using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public interface IAllergiesRepository
    {
        Task<List<Allergies>> GetAllAllergies();
    }
}
