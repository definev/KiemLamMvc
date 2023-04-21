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
        private readonly IDieuLuatService _dieuLuatService;
        private readonly IFileService _fileService;
        private readonly IChuongMucService _chuongMucService;
        public DieuLuatController(IChuongMucService chuongMucService,IDieuLuatService dieuLuatService, IFileService fileService)
        {
            _dieuLuatService = dieuLuatService;
            _fileService = fileService;
            _chuongMucService = chuongMucService;
        }
        public IActionResult Add()
        {
            var model = new DieuLuat();
            model.ChuongMucList = _chuongMucService.List().Select(a => new SelectListItem { Text = a.TenChuong, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(DieuLuat model)
        {
            model.ChuongMucList = _chuongMucService.List().Select(a => new SelectListItem { Text = a.TenChuong, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            var result = _dieuLuatService.Add(model);
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
            var model = _dieuLuatService.GetById(id);
            var selectedGenres = _dieuLuatService.GetGenreByMovieId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_chuongMucService.List(), "Id", "GenreName", selectedGenres);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DieuLuat model)
        {
            var selectedGenres = _dieuLuatService.GetGenreByMovieId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_chuongMucService.List(), "Id", "GenreName", selectedGenres);
            if (!ModelState.IsValid)
                return View(model);
            var result = _dieuLuatService.Update(model);
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
            var data = this._dieuLuatService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _dieuLuatService.Delete(id);
            return RedirectToAction(nameof(DieuLuatList));
        }



    }
}
