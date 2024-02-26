using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class DiseaseInformation
    {
        [Key]
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
    }
}
