using Microsoft.AspNetCore.Mvc;

namespace PatientInformationPortalWeb.Controllers
{
    public class PatientInformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult AddPatientInformation()
        {
            return View();
        }
    }
}
