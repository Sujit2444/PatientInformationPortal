using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientInformationPortalWeb.Models;
using PatientInformationPortalWeb.Models.ViewModels;
using PatientInformationPortalWeb.Repository;

namespace PatientInformationPortalWeb.Controllers
{
    public class PatientInformationController : Controller
    {
        private readonly IDiseaseInformationRepository _diseaseInformationRepository;
        private readonly INCDRepository _nCDRepository;
        private readonly IAllergiesRepository _allergiesRepository;
        private readonly IPatientInformationRepository _patientInformationRepository;
        public PatientInformationController(
            IDiseaseInformationRepository diseaseInformationRepository,
            INCDRepository nCDRepository,
            IAllergiesRepository allergiesRepository,
            IPatientInformationRepository patientInformationRepository
        )
        {
            _diseaseInformationRepository = diseaseInformationRepository;
            _nCDRepository = nCDRepository;
            _allergiesRepository = allergiesRepository;
            _patientInformationRepository = patientInformationRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPatient()
        {
            PatientInformationViewModel patientInformationViewModel =
                new PatientInformationViewModel();
            try
            {
                List<DiseaseInformation> diseaseList =
                    await _diseaseInformationRepository.GetAllDiseaseInformation();

                patientInformationViewModel.DiseaseInformationSelectList = new SelectList(
                    diseaseList.Select(
                        disease => new { Id = disease.DiseaseID, Name = disease.DiseaseName }
                    ),
                    "Id",
                    "Name"
                );
                ;

                patientInformationViewModel.EpilepsyStatusSelectList = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = Convert.ToInt32(EpilepsyStatus.Yes).ToString(),
                        Text = EpilepsyStatus.Yes.ToString()
                    },
                    new SelectListItem
                    {
                        Value = Convert.ToInt32(EpilepsyStatus.No).ToString(),
                        Text = EpilepsyStatus.No.ToString()
                    }
                };

                List<NCD> ncdList = await _nCDRepository.GetAllNCDs();
                patientInformationViewModel.LeftNCDSelectList = new SelectList(
                    ncdList.Select(ncd => new { Id = ncd.NCDID, Name = ncd.NCDName }),
                    "Id",
                    "Name"
                );

                List<Allergies> allergies = await _allergiesRepository.GetAllAllergies();
                patientInformationViewModel.LeftAllergiesSelectList = new SelectList(
                    allergies.Select(
                        allergy => new { Id = allergy.AllergiesID, Name = allergy.AllergiesName }
                    ),
                    "Id",
                    "Name"
                );
            }
            catch (Exception ex)
            {
                //throw;
            }

            return View(patientInformationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientInformationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatientInformation patientInformation = new PatientInformation();
                    patientInformation.Name = model.Name;
                    patientInformation.DiseaseID = model.SelectedDiseaseInformation;
                    patientInformation.EpilepsyStatus =
                        (EpilepsyStatus)model.SelectedEpilepsyStatus;
                    patientInformation.NCDs = new List<NCDDetail>();
                    if (model.SelectedRightNCDs != null)
                    {
                        foreach (var item in model.SelectedRightNCDs)
                        {
                            patientInformation.NCDs.Add(new NCDDetail { NCDID = item });
                        }
                    }

                    patientInformation.Allergies = new List<AllergiesDetail>();
                    if (model.SelectedRightAllergies != null)
                    {
                        foreach (var item in model.SelectedRightAllergies)
                        {
                            patientInformation.Allergies.Add(
                                new AllergiesDetail { AllergiesID = item }
                            );
                        }
                    }

                    await _patientInformationRepository.AddPatient(patientInformation);
                    return RedirectToAction("Index", "PatientInformation");
                }

                List<DiseaseInformation> diseaseList =
                    await _diseaseInformationRepository.GetAllDiseaseInformation();
                model.DiseaseInformationSelectList = new SelectList(
                    diseaseList.Select(
                        disease => new { Id = disease.DiseaseID, Name = disease.DiseaseName }
                    ),
                    "Id",
                    "Name"
                );
                ;

                model.EpilepsyStatusSelectList = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = Convert.ToInt32(EpilepsyStatus.Yes).ToString(),
                        Text = EpilepsyStatus.Yes.ToString()
                    },
                    new SelectListItem
                    {
                        Value = Convert.ToInt32(EpilepsyStatus.No).ToString(),
                        Text = EpilepsyStatus.No.ToString()
                    }
                };

                List<NCD> ncdList = await _nCDRepository.GetAllNCDs();
                model.LeftNCDSelectList = new SelectList(
                    ncdList.Select(ncd => new { Id = ncd.NCDID, Name = ncd.NCDName }),
                    "Id",
                    "Name"
                );

                List<Allergies> allergies = await _allergiesRepository.GetAllAllergies();
                model.LeftAllergiesSelectList = new SelectList(
                    allergies.Select(
                        allergy => new { Id = allergy.AllergiesID, Name = allergy.AllergiesName }
                    ),
                    "Id",
                    "Name"
                );
            }
            catch (Exception ex)
            {
                //throw;
            }

            return View(model);
        }
    }
}
