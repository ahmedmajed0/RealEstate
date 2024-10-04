using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using RealEstate.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {
        readonly ITeamService teamService;
        readonly IClassificationService classificationService;
        readonly IImagesService imagesService;
        public TeamController(ITeamService team, IClassificationService classification, IImagesService images)
        {
            teamService = team;
            classificationService = classification;
            imagesService = images;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(teamService.GetAll());
        }

        public IActionResult Add(int? id)
        {
            TbTeam model = new TbTeam();

            if (id != null)
            {
                model = teamService.GetById((int)id);
                return View(model);
            }
            else
            {
                return View(model);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TbTeam model, List<IFormFile> Files)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.MemberId == 0)
            {
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

                        model.Image = ImageName;
                    }
                }

                if (teamService.Add(model))
                {
                    return RedirectToAction(nameof(GetAll));
                }
            }
            //edit
            else
            {
                if (teamService.Edit(model))
                {
                    return RedirectToAction(nameof(GetAll));
                }

            }

            ViewBag.CustomError = "حدث خطأ ما";
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if (teamService.Delete(id))
                return Ok();


            return NotFound();

        }
    }
}
