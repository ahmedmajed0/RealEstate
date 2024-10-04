using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using RealEstate.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ResidentialController : Controller
    {
        readonly IResidentialService residentialService;
        readonly IClassificationService classificationService;
        readonly IImagesService imagesService;
        public ResidentialController(IResidentialService residential, IClassificationService classification, IImagesService images)
        {
            residentialService = residential;
            classificationService = classification;
            imagesService = images;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(residentialService.GetAll());
        }

        public IActionResult Add(int? id)
        {
            AddResidentialVwM model = new AddResidentialVwM();

            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.ResidentialSubClassi();

            if (id != null)
            {
                model.residential = residentialService.GetById((int)id);
                model.Image = imagesService.ResidentialImage((int)id);
                return View(model);
            }
            else
            {
                return View(model);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddResidentialVwM model, List<IFormFile> Files, List<IFormFile> vid)
        {

            if (!ModelState.IsValid)
            {
                model.listPurposes = classificationService.AllPurposes();
                model.SubClassifications = classificationService.ResidentialSubClassi();
                return View(model);
            }


            if(model.residential.ResidentialId == 0)
            {
                if (Files.Count == 0)
                {
                    model.listPurposes = classificationService.AllPurposes();
                    model.SubClassifications = classificationService.ResidentialSubClassi();
                    ViewBag.ImageError = "من فضلك ادخل صورة علي الاقل ";
                    return View(model);
                }

                model.residential.DateOfPuplish = DateTime.Now;
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
                        model.residential.Video = VideoName;
                    }
                }
                if (residentialService.Add(model.residential))
                {
                    int Residential_Id = residentialService.LastAddedId();
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
                            image.ResidentialId = Residential_Id;

                            model.ResidentialImages.Add(image);
                        }
                    }

                    imagesService.AddImages(model.ResidentialImages);
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
                            model.residential.Video = VideoName;
                        }
                    }
                }


                if (residentialService.Edit(model.residential))
                {
                    return RedirectToAction(nameof(GetAll));
                }

                model.Image = imagesService.ResidentialImage(model.residential.ResidentialId);


            }


            model.listPurposes = classificationService.AllPurposes();
            model.SubClassifications = classificationService.ResidentialSubClassi();
            ViewBag.CustomError = "حدث خطأ ما";
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if (residentialService.Delete(id) && imagesService.DeleteResidentialImages(id))
                return Ok();


            return NotFound();
        }


    }
}
