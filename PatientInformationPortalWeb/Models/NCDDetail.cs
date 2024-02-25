using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalWeb.Models
{
    public class NCDDetail
    {
        [Key]
        public int NCDDetailID { get; set; }
        public PatientInformation PatientID { get; set; }
        public NCD NCDID { get; set; }

    }
}
