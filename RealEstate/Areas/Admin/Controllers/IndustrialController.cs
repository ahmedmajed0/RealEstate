using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using RealEstate.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class IndustrialController : Controller
    {
        readonly IIndustrialService industrialService;
        readonly IClassificationService classificationService;
        readonly IImagesService imagesService;
        public IndustrialController(IIndustrialService industrial, IClassificationService classification, IImagesService images)
        {
            industrialService = industrial;
            classificationService = classification;
            imagesService = images;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(industrialService.GetAll());
        }

        public IActionResult Add(int? id)
        {
            AddIndustrialVwM model = new AddIndustrialVwM();

            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.IndustrialSubClassi();

            if (id != null)
            {
                model.industrial = industrialService.GetById((int)id);
                model.Image = imagesService.IndustrialImage((int)id);
                return View(model);
            }
            else
            {
                return View(model);
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddIndustrialVwM model, List<IFormFile> Files, List<IFormFile> vid)
        {

            if (!ModelState.IsValid)
            {
                model.listPurposes = classificationService.AllPurposes();
                model.SubClassifications = classificationService.IndustrialSubClassi();
                return View(model);
            }


            if (model.industrial.IndustrialId == 0)
            {
                if (Files.Count == 0)
                {
                    model.listPurposes = classificationService.AllPurposes();
                    model.SubClassifications = classificationService.IndustrialSubClassi();
                    ViewBag.ImageError = "من فضلك ادخل صورة علي الاقل ";
                    return View(model);
                }

                model.industrial.DateOfPuplish = DateTime.Now;
                //add  video
                foreach (var file in vid)
                {
                    if (file.Length > 0)
                    {
                        string VideoName = Guid.NewGuid().ToString() + ".mp4";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", VideoName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        model.industrial.Video = VideoName;
                    }
                }
                if (industrialService.Add(model.industrial))
                {
                    int Industrial_Id = industrialService.LastAddedId();
                    //add image
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
                            TbImage image = new TbImage();
                            image.ImageName = ImageName;
                            image.IndustrialId = Industrial_Id;

                            model.IndustrialImages.Add(image);
                        }
                    }
                    imagesService.AddImages(model.IndustrialImages);
                    return RedirectToAction(nameof(GetAll));
                }
            }
            //edit
            else
            {
                if (vid.Count != 0)
                {
                    foreach (var file in vid)
                    {
                        if (file.Length > 0)
                        {
                            string VideoName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", VideoName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            model.industrial.Video = VideoName;
                        }
                    }
                }
                if (industrialService.Edit(model.industrial))
                {
                    return RedirectToAction(nameof(GetAll));
                }

                model.Image = imagesService.IndustrialImage(model.industrial.IndustrialId);


            }


            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.ResidentialSubClassi();
            ViewBag.CustomError = "حدث خطأ ما";
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if (industrialService.Delete(id) && imagesService.DeleteIndustrialImages(id))
                return Ok();

            return NotFound();
        }
    }
}
