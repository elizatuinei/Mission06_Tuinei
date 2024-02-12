using Microsoft.AspNetCore.Mvc;
using Mission06_Tuinei.Models;
using System.Diagnostics;

namespace Mission06_Tuinei.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
            // constructor, taking the thing passed int emporarily and
            // making it a thing that is visible
            //_logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewMovieForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMovieForm(Application response)
        {
            return View("Confirmation", response);
        }

    }
}
