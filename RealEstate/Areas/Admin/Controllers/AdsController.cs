using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bl;
using Domains;
using RealEstate.Areas.Admin.Models;

namespace RealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdsController : Controller
    {
        readonly IAdsServices IAdsServices;

        public AdsController(IAdsServices ad)
        {
            IAdsServices = ad;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            AdsVwModel model = new AdsVwModel();

            model.AllAds = IAdsServices.AllAds();

            if (model.AllAds.Count != 0)
                model.Ad = model.AllAds.FirstOrDefault();

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AdsVwModel model, List<IFormFile> Files)
        {
            model.AllAds = IAdsServices.AllAds();


            if (Files.Count == 0)
            {
                ViewBag.ImageError = "من فضلك ادخل صورة  ";
                return View(model);
            }

            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                    }

                    model.Ad.ImageName = ImageName;
                }
            }

            if(model.Ad.AdId == 0)
            {
                if (IAdsServices.Add(model.Ad))
                {
                    ViewBag.AddSuccess = "تم اضافة الاعلان";
                    return RedirectToAction(nameof(Add));
                }
            }
            else
            {
                IAdsServices.Edit(model.Ad);
                ViewBag.EditSuccess = "تم تعديل الاعلان";
                return RedirectToAction(nameof(Add));
            }



            ViewBag.CustomError = "حدث خطأ ما";
            return View(model);
        }


    }
}
