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
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie());
        }
        [HttpPost]
        public IActionResult NewMovieForm(Movie response)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();


            return View("Confirmation", response);

            }

            else

            {

                ViewBag.Categories = _context.Categories.Include("Category").ToList(); // Assuming you want to execute the query and materialize the results

                return View(response);
            }

        }

        [HttpGet]
        public IActionResult MovieSubmissions()
        // go out to context file and applications table
        // and go find...
        {
            var movieList = _context.Movies.Include("Category").ToList();

            return View(movieList);
        }

        [HttpGet]
        public IActionResult Edit(int MovieFormID)
        {
            var movieEdits = _context.Movies
                .Single(x => x.MovieId == MovieFormID);

            ViewBag.Categories = _context.Categories.ToList();

            return View("NewMovieForm", movieEdits);
        }

        [HttpPost]
        public IActionResult Edit(Movie editedApplication)
        {
            if(ModelState.IsValid)
            {
                _context.Update(editedApplication);
                _context.SaveChanges();

                return RedirectToAction("MovieSubmissions");
            }    
            else
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View("NewMovieForm", editedApplication);
            }

        }


        public IActionResult Delete(int MovieFormID)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == MovieFormID);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Movie deletedInfo)
        {

            // Delete the record and save the change to the db
            _context.Movies.Remove(deletedInfo);
            _context.SaveChanges();

            // redirect to the Collection action to show the records
            return RedirectToAction("MovieSubmissions");
        }



    }
}
