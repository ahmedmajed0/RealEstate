using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using RealEstate.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AgriculturalController : Controller
    {
        readonly IAgriculturalService agriculturalService;
        readonly IClassificationService classificationService;
        readonly IImagesService imagesService;
        public AgriculturalController(IAgriculturalService agricultural, IClassificationService classification, IImagesService images)
        {
            agriculturalService = agricultural;
            classificationService = classification;
            imagesService = images;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(agriculturalService.GetAll());
        }

        public IActionResult Add(int? id)
        {
            AddAgriculturalVwM model = new AddAgriculturalVwM();

            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.AgriculturalSubClassi();

            if (id != null)
            {
                model.agricultural = agriculturalService.GetById((int)id);
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
        public async Task<IActionResult> Add(AddAgriculturalVwM model, List<IFormFile> Files, List<IFormFile> vid)
        {

            if (!ModelState.IsValid)
            {
                model.listPurposes = classificationService.AllPurposes();
                model.SubClassifications = classificationService.AgriculturalSubClassi();
                return View(model);
            }


            if (model.agricultural.AgrculturalId == 0)
            {
                if (Files.Count == 0)
                {
                    model.listPurposes = classificationService.AllPurposes();
                    model.SubClassifications = classificationService.AgriculturalSubClassi();
                    ViewBag.ImageError = "من فضلك ادخل صورة علي الاقل ";
                    return View(model);
                }

                model.agricultural.DateOfPuplish = DateTime.Now;
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
                        model.agricultural.Video = VideoName;
                    }
                }
                if (agriculturalService.Add(model.agricultural))
                {
                    int Agricultural_Id = agriculturalService.LastAddedId();
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
                            image.AgrculturalId = Agricultural_Id;

                            model.AgriculturalImages.Add(image);
                        }
                    }
                    imagesService.AddImages(model.AgriculturalImages);
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
                            model.agricultural.Video = VideoName;
                        }
                    }
                }
                if (agriculturalService.Edit(model.agricultural))
                {
                    return RedirectToAction(nameof(GetAll));
                }

                model.Image = imagesService.AgriculturalImage(model.agricultural.AgrculturalId);


            }


            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.AgriculturalSubClassi();
            ViewBag.CustomError = "حدث خطأ ما";
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if (agriculturalService.Delete(id) && imagesService.DeleteAgriculturalImages(id))
                return Ok();

            return NotFound();
        }
    }
}
