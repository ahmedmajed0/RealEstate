using Microsoft.AspNetCore.Mvc;
using RealEstate.Areas.Admin.Models;
using Bl;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {
        readonly IResidentialService residentialService;
        readonly IAgriculturalService agriculturalService;
        readonly ICommercialService commercialService;
        readonly IIndustrialService industrialService;
        public HomeController(IResidentialService residential, IAgriculturalService agricultural, ICommercialService commercial, IIndustrialService industrial)
        {
            residentialService = residential;
            agriculturalService = agricultural;
            commercialService = commercial;
            industrialService = industrial;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            HomePageVwM model = new HomePageVwM();
            model.ResidentialNo = residentialService.ResidentialNo();
            model.CommercialNo = commercialService.CommercialNo();
            model.industrialNo = industrialService.IndustrialNo();
            model.AgriculturalNo = agriculturalService.AgriculturalNo();
            return View(model);
        }
    }
}
