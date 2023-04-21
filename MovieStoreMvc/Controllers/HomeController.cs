using Microsoft.AspNetCore.Mvc;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDieuLuatService _dieuLuatService;
        public HomeController(IDieuLuatService dieuLuatService)
        {
            _dieuLuatService = dieuLuatService;
        }
        public IActionResult Index(string term="", int currentPage = 1)
        {
            var movies = _dieuLuatService.List(term,true,currentPage);
            return View(movies);
        }

        public IActionResult MovieDetail(int movieId)
        {
            var movie = _dieuLuatService.GetById(movieId);
            return View(movie);
        }

    }
}
