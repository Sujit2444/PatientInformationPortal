using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class AllergiesDetail
    {
        [Key]
        public int AllergiesDetailId { get; set; }
        public PatientInformation PatientID { get; set; }
        public AllergyInformation AllergiesID { get; set; }
    }
}
