using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Tuinei.Models;
using SQLitePCL;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
// create a view for the index that leads to the get to know joel page
// also let users update the database using a form
// send users a confirmation when they've successfully input data
namespace Mission06_Tuinei.Controllers
{
    public class HomeController : Controller

    {
        private MovieFormContext _context;
        // when a homecontrller is built lets bring an instance 
        // of the movieform 
        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }


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
        public IActionResult NewMovieForm(Mission06_Tuinei.Models.Application response)
        {
            _context.Applications.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
        public IActionResult MovieSubmissions ()
        // go out to context file and applications table
        // and go find...
        {

            var applications = _context.Applications
                .Where(x => x.Rating == "G" || x.Rating == "PG" || x.Rating == "PG-13")
                .OrderBy(x => x.Title)
                .ToList(); // Assuming you want to execute the query and materialize the results

            return View(applications);
        }

        public IActionResult Edit(int MovieFormID)
        {
            var applications = _context.Applications.Find(MovieFormID);

            if (applications == null)
            {
                // Handle the case where the movie ID is not found (e.g., show an error page)
                return RedirectToAction("MovieSubmissions");
            }

            return View(applications);
        }

        [HttpPost]
        public IActionResult Edit(Mission06_Tuinei.Models.Application editedApplication)
        {
            _context.Update(editedApplication);
            _context.SaveChanges();
            return RedirectToAction("MovieSubmissions");
        }


        public IActionResult Delete(int MovieFormID)
        {
            var application = _context.Applications.Find(MovieFormID);
            return View(application);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int MovieFormID)
        {
            var application = _context.Applications.Find(MovieFormID);

            if (application == null)
            {
                // Handle the case where the movie ID is not found (e.g., show an error page)
                return RedirectToAction("MovieSubmissions");
            }

            _context.Applications.Remove(application);
            _context.SaveChanges();
            return RedirectToAction("MovieSubmissions");
        }



    }
}
