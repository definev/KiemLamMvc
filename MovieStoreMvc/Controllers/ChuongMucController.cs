using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    [Authorize]
    public class ChuongMucController : Controller
    {
        private readonly IChuongMucService _chuongMucService;

        public ChuongMucController(IChuongMucService chuongMucService)
        {
            _chuongMucService = chuongMucService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ChuongMuc model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _chuongMucService.Add(model);
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
            var data = _chuongMucService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(ChuongMuc model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _chuongMucService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(ChuongMucList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }
        
        public IActionResult ChuongMucList()
        {
            var data = this._chuongMucService.List().ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _chuongMucService.Delete(id);
            return RedirectToAction(nameof(ChuongMucList));
        }
    }
}