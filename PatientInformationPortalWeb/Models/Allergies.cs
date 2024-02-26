using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class Allergies
    {
        [Key]
        public int AllergiesID { get; set; }
        public string AllergiesName { get; set; }
    }
}
