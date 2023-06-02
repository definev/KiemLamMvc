using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreMvc.Models.Domain;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    [Authorize]
    public class ChuongMucController : Controller
    {
        private readonly IChaptersService _services;

        public ChuongMucController(IChaptersService services)
        {
            _services = services;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Chapters model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.CreateTime = DateTime.Now.ToLongDateString();
            model.UpdateTime = DateTime.Now.ToLongDateString();
            var result = _services.Add(model);
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
            var data = _services.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Chapters model)
        {
            model.UpdateTime = DateTime.Now.ToLongDateString();
            if (!ModelState.IsValid)
                return View(model);
            var result = _services.Update(model);
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
            var data = this._services.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _services.Delete(id);
            return RedirectToAction(nameof(ChuongMucList));
        }
    }
}