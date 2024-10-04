using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class EstateDetailsController : Controller
    {
        readonly IResidentialService residentialService;
        readonly ICommercialService commercialService;
        readonly IAgriculturalService agriculturalService;
        readonly IIndustrialService industrialService;
        readonly IImagesService imagesService;


        public EstateDetailsController(IResidentialService residential, ICommercialService commercial,
         IAgriculturalService agricultural, IIndustrialService industrial, IImagesService images)
        {
            residentialService = residential;
            commercialService = commercial;
            agriculturalService = agricultural;
            industrialService = industrial;
            imagesService = images;
        }
        public IActionResult Residential(int id)
        {
            ResidentialDetails model = new ResidentialDetails();
            model.residential = residentialService.GetById(id);
            model.images = imagesService.ResidentialImages(id);

            return View(model);
        }

        public IActionResult Agricultural(int id)
        {
            AgriculturalDetails model = new AgriculturalDetails();
            model.agricultural = agriculturalService.GetById(id);
            model.images = imagesService.AgriculturalImages(id);
            return View(model);
        }

        public IActionResult Commercial(int id)
        {
            CommercialDetails model = new CommercialDetails();
            model.commercial = commercialService.GetById(id);
            model.images = imagesService.CommercialImages(id);
            return View(model);
        }

        public IActionResult Industrial(int id)
        {
            IndutrialDetails model = new IndutrialDetails();
            model.industrial = industrialService.GetById(id);
            model.images = imagesService.IndustrialImages(id);
            return View(model);
        }
    }
}
