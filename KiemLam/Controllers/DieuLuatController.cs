using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    [Authorize]
    public class DieuLuatController : Controller
    {
        private readonly ISectionsService _service;
        private readonly IChaptersService _chaptersService;

        public DieuLuatController(IChaptersService chaptersService, ISectionsService service)
        {
            _service = service;
            _chaptersService = chaptersService;
        }
        public IActionResult Add()
        {
            var model = new Sections();
            model.ChaptersList = _chaptersService //
                .List()
                .Chapters?
                .ToList()
                .Select(a => new SelectListItem { Text = a.Title, Value = a.ID.ToString() });
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Sections model)
        {
            model.ChaptersList = _chaptersService //
                .List()
                .Chapters?
                .ToList()
                .Select(a => new SelectListItem { Text = a.Title, Value = a.ID.ToString() });
            
            if (!ModelState.IsValid)
                return View(model);
            var result = _service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Sections model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _service.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(DieuLuatList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult DieuLuatList()
        {
            var data = this._service.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return RedirectToAction(nameof(DieuLuatList));
        }



    }
}
