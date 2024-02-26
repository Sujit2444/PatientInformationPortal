using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class PatientInformation
    {
        [Key]
        public int PatientID { get; set; }
        public string Name { get; set; }
        public List<NCDDetail> NCDs { get; set; }
        public List<AllergiesDetail> Allergies { get; set; }
        public EpilepsyStatus EpilepsyStatus { get; set; }
    }

}
