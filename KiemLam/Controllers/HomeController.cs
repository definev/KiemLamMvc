using Microsoft.AspNetCore.Mvc;
using MovieStoreMvc.Repositories.Abstract;

namespace MovieStoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISectionsService _service;
        public HomeController(ISectionsService service)
        {
            _service = service;
        }
        public IActionResult Index(string term="", int currentPage = 1)
        {
            var movies = _service.List(term,true,currentPage);
            return View(movies);
        }

        public IActionResult MovieDetail(int movieId)
        {
            var movie = _service.GetById(movieId);
            return View(movie);
        }

    }
}
