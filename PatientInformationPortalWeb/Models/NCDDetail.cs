using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalWeb.Models
{
    public class NCDDetail
    {
        [Key]
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int NCDID { get; set; }
        public PatientInformation Patient { get; set; }
        public NCD NCD { get; set; }

    }
}
