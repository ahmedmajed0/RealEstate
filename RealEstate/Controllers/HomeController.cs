using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using System.Diagnostics;
using Bl;
using Domains;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        readonly IResidentialService residentialService;
        readonly ICommercialService commercialService;
        readonly IAgriculturalService agriculturalService;
        readonly IIndustrialService industrialService;
        readonly ITeamService teamService;
        readonly IClassificationService classificationService;
        readonly IAdsServices adsServices;

        public HomeController(IResidentialService residential, ICommercialService commercial,IAdsServices ads,
            ITeamService team,IAgriculturalService agricultural, IIndustrialService industrial, IClassificationService classification)
        {
            residentialService = residential;
            commercialService = commercial;
            agriculturalService = agricultural;
            industrialService = industrial;
            teamService = team;
            classificationService = classification;
            adsServices = ads;
        }



        public IActionResult Index()
        {
            HomePageVwModel model = new HomePageVwModel();
            model.listResidential = residentialService.AllForHomePage();
            model.listIndustrial = industrialService.AllForHomePage();
            model.listCommercial = commercialService.AllForHomePage();
            model.listAgricultural = agriculturalService.AllForHomePage();
            model.listmembers = teamService.GetAll();
            model.classifications = classificationService.AllClassification();
            model.AllPurposese = classificationService.AllPurposes();
            model.Ads = adsServices.AllAds().FirstOrDefault();

            return View(model);
        }


        
        public IActionResult GetSubs(int classificationId)
        {

            var SubClassification = classificationService.AllSubClassification().Where(a => a.ClassificationId == classificationId).ToList();
            return Ok(SubClassification);
        }

        public IActionResult Search()
        {
            HomePageVwModel model = new HomePageVwModel();
            model.Ads = adsServices.AllAds().FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(HomePageVwModel model)
        {
            model.listmembers = teamService.GetAll();
            model.classifications = classificationService.AllClassification();
            model.AllPurposese = classificationService.AllPurposes();
            model.Ads = adsServices.AllAds().FirstOrDefault();

            if (!ModelState.IsValid)
                return View(model);

            //سكني
            if (model.ClassificationId == 1)
                model.listResidential = residentialService.AllForSearch(model.PurposeId, model.SubClassificationId);

            //تجاري
            if (model.ClassificationId == 2)
                model.listCommercial = commercialService.AllForSearch(model.PurposeId, model.SubClassificationId);

            //زراعي
            if (model.ClassificationId == 3)
                model.listAgricultural = agriculturalService.AllForSearch(model.PurposeId, model.SubClassificationId);

            //صناعي
            if (model.ClassificationId == 4)
                model.listIndustrial = industrialService.AllForSearch(model.PurposeId, model.SubClassificationId);



            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}