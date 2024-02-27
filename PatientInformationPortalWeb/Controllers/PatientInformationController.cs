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

        [HttpGet]
        public async Task<IActionResult> UserView(int id)
        {
            PatientInformationViewModel patientInformationViewModel = new PatientInformationViewModel();
            try
            {
               PatientInformation patientInformation=await _patientInformationRepository.GetPatientInformationById(id);
                if (patientInformation == null)
                {
                    return RedirectToAction("Index", "PatientInformation");
                }

                patientInformationViewModel.Name = patientInformation.Name;
                patientInformationViewModel.PatientID = patientInformation.PatientID;
                patientInformationViewModel.SelectedDiseaseInformation=patientInformation.DiseaseID;
                patientInformationViewModel.SelectedEpilepsyStatus=Convert.ToInt32(patientInformation.EpilepsyStatus);
               
                patientInformationViewModel.RightNCDSelectList = new SelectList(
                    patientInformation.NCDs.Select(ncd => new { Id = ncd.NCDID, Name = ncd.NCD.NCDName }),
                    "Id",
                    "Name"
                );
                patientInformationViewModel.RightAllergiesSelectList= new SelectList(
                    patientInformation.Allergies.Select(al => new { Id = al.AllergiesID, Name = al.Allergies.AllergiesName }),
                    "Id",
                    "Name"
                );
                await PopulateAllSelectList(patientInformationViewModel);

                List<int> ncdIDsToRemove = patientInformation.NCDs.Select(ncd => ncd.NCDID).ToList();
                List<SelectListItem> ncdSelectListItem = patientInformationViewModel.LeftNCDSelectList
                 .Where(item => !ncdIDsToRemove.Contains(Convert.ToInt32(item.Value)))
                    .ToList();
                patientInformationViewModel.LeftNCDSelectList = new SelectList(ncdSelectListItem, "Value", "Text");


                List<int> allergiesIDsToRemove = patientInformation.Allergies.Select(allergy => allergy.AllergiesID).ToList();
                List<SelectListItem> algSelectListItem = patientInformationViewModel.LeftAllergiesSelectList
                 .Where(item => !allergiesIDsToRemove.Contains(Convert.ToInt32(item.Value)))
                    .ToList();
                patientInformationViewModel.LeftAllergiesSelectList = new SelectList(algSelectListItem, "Value", "Text");

            }
            catch (Exception ex)
            { }
            return View(patientInformationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserView(PatientInformationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PatientInformation patientInformation = new PatientInformation();
                    patientInformation.PatientID = model.PatientID;
                    patientInformation.Name = model.Name;
                    patientInformation.DiseaseID = model.SelectedDiseaseInformation;
                    patientInformation.EpilepsyStatus = (EpilepsyStatus)model.SelectedEpilepsyStatus;
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

                    await _patientInformationRepository.UpdatePatient(patientInformation);
                    return RedirectToAction("Index", "PatientInformation");
                }

                await PopulateAllSelectList(model);
            }
            catch (Exception ex)
            { }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PatientInformation> patientInformationList = new List<PatientInformation>();
            try
            {
               patientInformationList = await _patientInformationRepository.GetAllPatientInformation();
            }
            catch (Exception ex)
            { }
            return View(patientInformationList);
        }

        [HttpGet]
        public async Task<IActionResult> AddPatient()
        {
            PatientInformationViewModel patientInformationViewModel =
                new PatientInformationViewModel();
            try
            {
                await PopulateAllSelectList(patientInformationViewModel);
            }
            catch (Exception ex)
            { }

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
                    patientInformation.EpilepsyStatus =(EpilepsyStatus)model.SelectedEpilepsyStatus;
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

                await PopulateAllSelectList(model);
            }
            catch (Exception ex)
            { }

            return View(model);
        }

        private async Task PopulateAllSelectList(PatientInformationViewModel model)
        {
            try
            {
                List<DiseaseInformation> diseaseList = await _diseaseInformationRepository.GetAllDiseaseInformation();
                model.DiseaseInformationSelectList = new SelectList(
                    diseaseList.Select(
                        disease => new { Id = disease.DiseaseID, Name = disease.DiseaseName }
                    ),
                    "Id",
                    "Name"
                );
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
            { }
        }
    }
}
