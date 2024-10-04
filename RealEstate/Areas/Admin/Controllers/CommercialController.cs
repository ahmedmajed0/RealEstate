using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using RealEstate.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommercialController : Controller
    {
        readonly ICommercialService commercialService;
        readonly IClassificationService classificationService;
        readonly IImagesService imagesService;
        public CommercialController(ICommercialService commercial, IClassificationService classification, IImagesService images)
        {
            commercialService = commercial;
            classificationService = classification;
            imagesService = images;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(commercialService.GetAll());
        }

        public IActionResult Add(int? id)
        {
            AddCommercialVwM model = new AddCommercialVwM();

            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.CommercialSubClassi();

            if (id != null)
            {
                model.commercial = commercialService.GetById((int)id);
                model.Image = imagesService.AgriculturalImage((int)id);
                return View(model);
            }
            else
            {
                return View(model);
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddCommercialVwM model, List<IFormFile> Files, List<IFormFile> vid)
        {

            if (!ModelState.IsValid)
            {
                model.listPurposes = classificationService.AllPurposes();
                model.SubClassifications = classificationService.CommercialSubClassi();
                return View(model);
            }


            if (model.commercial.CommercialId == 0)
            {
                if (Files.Count == 0)
                {
                    model.listPurposes = classificationService.AllPurposes();
                    model.SubClassifications = classificationService.CommercialSubClassi();
                    ViewBag.ImageError = "من فضلك ادخل صورة علي الاقل ";
                    return View(model);
                }

                model.commercial.DateOfPuplish = DateTime.Now;
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
                        model.commercial.Video = VideoName;
                    }
                }
                if (commercialService.Add(model.commercial))
                {
                    int Commercial_Id = commercialService.LastAddedId();
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
                            image.CommercialId = Commercial_Id;

                            model.CommercialImages.Add(image);
                        }
                    }
                    imagesService.AddImages(model.CommercialImages);
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
                            model.commercial.Video = VideoName;
                        }
                    }
                }
                if (commercialService.Edit(model.commercial))
                {
                    return RedirectToAction(nameof(GetAll));
                }

                model.Image = imagesService.CommercialImage(model.commercial.CommercialId);


            }


            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.CommercialSubClassi();
            ViewBag.CustomError = "حدث خطأ ما";
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if (commercialService.Delete(id) && imagesService.DeleteCommercialImages(id))
                return Ok();

            return NotFound();
        }
    }
}
