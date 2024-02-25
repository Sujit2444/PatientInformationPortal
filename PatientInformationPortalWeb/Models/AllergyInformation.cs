using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class AllergyInformation
    {
        [Key]
        public int AllergiesID { get; set; }
        public string AllergiesName { get; set; }
    }
}
