using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class PatientInformation
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public List<DiseaseInformation> DiseaseInformationList { get; set; }
        public EpilepsyStatus EpilepsyStatus { get; set; }
    }

}
