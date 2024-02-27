using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class AllergiesDetail
    {
        [Key]
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int AllergiesID { get; set; }
        public PatientInformation Patient { get; set; }
        public Allergies Allergies { get; set; }
    }
}
