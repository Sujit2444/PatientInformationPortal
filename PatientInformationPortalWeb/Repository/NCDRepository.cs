using Microsoft.EntityFrameworkCore;
using PatientInformationPortalWeb.Data;
using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Repository
{
    public class NCDRepository:INCDRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public NCDRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<NCD>> GetAllNCDs()
        {
            return await _applicationDBContext.NCDs.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
