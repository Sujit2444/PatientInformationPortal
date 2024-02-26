using Microsoft.EntityFrameworkCore;
using PatientInformationPortalWeb.Data;
using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public class AllergiesRepository:IAllergiesRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public AllergiesRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<Allergies>> GetAllAllergies()
        {
            return await _applicationDBContext.Allergies.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
